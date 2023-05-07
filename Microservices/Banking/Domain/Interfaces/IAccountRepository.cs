using Banking.Domain.Models;

namespace Banking.Domain.Interfaces;

    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(int id);
        void Add(Account account);
        void Edit(Account account);
        void Delete(int id);
    
}