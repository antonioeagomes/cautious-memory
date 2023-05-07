using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Commands;
using Domain.Core.Bus;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
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

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _accountRepository.GetAll();
        }

        public async Task<Account> GetById(int id)
        {
            return await _accountRepository.GetById(id);
        }

        public async Task TransferFunds(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
            );

            await _bus.SendCommandAsync(createTransferCommand);

        }
    }
}