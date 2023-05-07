// using Transfer.Application.Models;
using Transfer.Domain.Models;

namespace TransferApplication.Interfaces;

public interface ITransferService
{
    Task<IEnumerable<Transfer.Domain.Models.Transfer>> GetAll();

}
