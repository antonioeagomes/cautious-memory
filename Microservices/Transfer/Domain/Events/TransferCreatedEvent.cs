using Domain.Core.Events;

namespace Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public TransferCreatedEvent(int fromAccount, int toAccount, decimal transferAmount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferAmount = transferAmount;
        }

        public int FromAccount { get; private set; }
        public int ToAccount { get; private set; }
        public decimal TransferAmount { get; private set; }
    }
}