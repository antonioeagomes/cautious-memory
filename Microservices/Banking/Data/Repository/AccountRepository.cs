using Banking.Data.Context;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Data.Repository;

public class AccountRepository : IAccountRepository
{
    private BankingDbContext _context;

    public AccountRepository(BankingDbContext context)
    {
        _context = context;
    }

    public void Add(Account account)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Edit(Account account)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Account>>GetAll()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetById(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }
}