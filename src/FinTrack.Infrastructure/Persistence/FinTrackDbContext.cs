using Microsoft.EntityFrameworkCore;
using FinTrack.Domain.Entities;

namespace FinTrack.Infrastructure.Datas
{
    public class FinTrackDbContext : DbContext
    {
        public FinTrackDbContext(DbContextOptions<FinTrackDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(builder =>
            {
                builder.OwnsOne(t => t.Amount, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("Amount").HasPrecision(18, 2);
                    money.Property(m => m.Currency).HasColumnName("Currency").HasMaxLength(3);        
                });
                builder.Property(t => t.Type).HasConversion<string>();
            });
        }
    }
}
