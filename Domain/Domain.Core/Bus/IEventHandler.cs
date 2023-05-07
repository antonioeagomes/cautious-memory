using Domain.Core.Events;

namespace Domain.Core.Bus;

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
{
    Task HandleAsync(TEvent e);
}

public interface IEventHandler { }
