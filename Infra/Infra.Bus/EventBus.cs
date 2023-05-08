using System.Text;
using System.Text.Json;
using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Infra.Bus;

public sealed class EventBus : IEventBus
{
    private readonly IMediator _mediatr;
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly List<Type> _eventTypes;

    private readonly IServiceScopeFactory _serviceScopeFactory;

    public EventBus(IMediator mediatr, IServiceScopeFactory serviceScopeFactory)
    {
        _handlers = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
        _mediatr = mediatr;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var eventName = @event.GetType().Name;
        channel.QueueDeclare(eventName, false, false, false, null);

        var message = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", eventName, null, body);
    }

    public async Task<bool> SendCommandAsync<T>(T command) where T : BaseCommand
    {
        return await _mediatr.Send(command);

    }

    public void Subscribe<T, THandler>()
        where T : Event
        where THandler : IEventHandler<T>
    {
        var eventName = nameof(T);
        var handlerType = typeof(THandler);

        if (!_eventTypes.Contains(typeof(T)))
        {
            _eventTypes.Add(typeof(T));
        }

        if (!_handlers.ContainsKey(eventName))
        {
            _handlers.Add(eventName, new List<Type>());
        }

        if (_handlers[eventName].Any(s => s.GetType() == handlerType))
        {
            throw new Exception($"Handler {handlerType.Name} is already registered for {eventName}");
        }

        _handlers[eventName].Add(handlerType);

        StartBasicConsume<T>();

    }

    private void StartBasicConsume<T>() where T : Event
    {
        var factory = new ConnectionFactory() { HostName = "localhost", DispatchConsumersAsync = true };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var eventName = nameof(T);

        channel.QueueDeclare(eventName, false, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.Received += Consumer_Received;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.ToArray());

        try
        {
            await ProcessEvent(eventName, message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscriptions = _handlers[eventName];

                foreach (var item in subscriptions)
                {
                    var handler = scope.ServiceProvider.GetService(item);

                    if (handler == null) continue;

                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var e = JsonSerializer.Deserialize(message, eventType);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { e });
                }
            }


        }
    }
}