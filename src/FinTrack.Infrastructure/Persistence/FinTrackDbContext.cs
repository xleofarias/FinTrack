using Microsoft.EntityFrameworkCore;
using FinTrack.Domain.Entities;

namespace FinTrack.Infrastructure.Datas
{
    public class FinTrackDbContext : DbContext
    {
        public FinTrackDbContext(DbContextOptions<FinTrackDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
