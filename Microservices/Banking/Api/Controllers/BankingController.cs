using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAll()
        {
            return Ok(await _accountService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountTransfer accountTransfer){
            await _accountService.TransferFunds(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}