using Domain.Core.Bus;
using Transfer.Domain.Events;

namespace Transfer.Domain.EventHandlers;

public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
{
    public TransferEventHandler()
    {
        
    }
    public Task HandleAsync(TransferCreatedEvent e)
    {
        return Task.CompletedTask;
    }
}
