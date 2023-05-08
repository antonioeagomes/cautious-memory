// using Transfer.Application.Models;
using Transfer.Domain.Models;

namespace TransferApplication.Interfaces;

public interface ITransferService
{
    public Task<IEnumerable<Transfer.Domain.Models.Transfer>> GetAll();

    public Task Add(Transfer.Domain.Models.Transfer transfer);

}
