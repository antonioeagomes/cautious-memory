using Microsoft.AspNetCore.Mvc;
using TransferApplication.Interfaces;

namespace Transfer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transfer.Domain.Models.Transfer>>> GetAll()
    {
        return Ok(await _transferService.GetAll());
    }
}
