using Domain.Core.Bus;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;

namespace Transfer.Domain.EventHandlers;

public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
{
    private readonly ITransferRepository _transferRepository;
    public TransferEventHandler(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }
    public Task HandleAsync(TransferCreatedEvent e)
    {
        _transferRepository.Add(new Transfer.Domain.Models.Transfer {
            FromAccount = e.FromAccount,
            ToAccount = e.ToAccount,
            Amount = e.TransferAmount
        });

        return Task.CompletedTask;
    }
}
