using Microsoft.EntityFrameworkCore;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;

namespace Transfer.Data.Repository;

public class TransferRepository : ITransferRepository
{
    private TransferDbContext _context;

    public TransferRepository(TransferDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Domain.Models.Transfer>> GetAll()
    {

        return await _context.Transfers.ToListAsync();

    }
}
