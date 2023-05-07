using Banking.Application.Models;
using Banking.Domain.Models;

namespace Banking.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(int id);
        void Add(Account account);
        void Edit(Account account);
        void Delete(int id);
        Task TransferFunds(AccountTransfer accountTransfer);
    }
}