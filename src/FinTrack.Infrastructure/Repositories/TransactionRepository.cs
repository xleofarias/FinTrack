using FinTrack.Application.Transactions;
using FinTrack.Domain.Entities;
using FinTrack.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositorys
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinTrackDbContext _context;

        public TransactionRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Transactions.ToListAsync(ct);
        }

        public async Task AddAsync(Transaction transaction, CancellationToken ct = default)
        {
            await _context.Transactions.AddAsync(transaction, ct);

            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Transaction transaction, CancellationToken ct = default)
        {
            _context.Transactions.Update(transaction);

            await _context.SaveChangesAsync(ct);
        }
    }
}
