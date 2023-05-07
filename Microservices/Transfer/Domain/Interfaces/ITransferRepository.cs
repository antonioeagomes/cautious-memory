namespace Transfer.Domain.Interfaces;

public interface ITransferRepository
{
    public Task<IEnumerable<Transfer.Domain.Models.Transfer>> GetAll();
}
