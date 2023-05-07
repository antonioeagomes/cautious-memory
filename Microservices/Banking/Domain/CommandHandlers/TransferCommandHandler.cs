using Banking.Domain.Commands;
using Domain.Core.Bus;
using Banking.Domain.Events;
using MediatR;

namespace Banking.Domain.CommandHandlers;

    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransferCreatedEvent(request.FromAccount, request.ToAccount, request.TransferAmount));

            return Task.FromResult(true);
        }
    }
