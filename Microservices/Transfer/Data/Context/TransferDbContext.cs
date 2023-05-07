using Microsoft.EntityFrameworkCore;
using Transfer.Domain.Models;

namespace Transfer.Data.Context;

public class TransferDbContext : DbContext
{
    public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
    {
    }

    public DbSet<Transfer.Domain.Models.Transfer> Transfers { get; set; }


}
