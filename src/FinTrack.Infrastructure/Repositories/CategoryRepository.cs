using FinTrack.Domain.Entities;
using FinTrack.Infrastructure.Datas;
using FinTrack.Application.Categories;

namespace FinTrack.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinTrackDbContext _context;

        public CategoryRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category, CancellationToken ct = default)
        {
            await _context.Categories.AddAsync(category, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Categories.FindAsync(id, ct);
        }

        public async Task UpdateAsync(Category category, CancellationToken ct = default)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(ct);
        }
    }
}