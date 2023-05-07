using Domain.Core.Commands;
using Domain.Core.Events;

namespace Domain.Core.Bus;

public interface IEventBus
{
    Task<bool> SendCommandAsync<T>(T command) where T : BaseCommand;

    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, THandler>() 
        where T : Event
        where THandler : IEventHandler<T>;
}