using Domain.Core.Commands;

namespace Banking.Domain.Commands
{
    public class TransferCommand : BaseCommand
    {
        public int FromAccount { get; protected set; }
        public int ToAccount { get; protected set; }
        public decimal TransferAmount { get; protected set; }
    }
}
