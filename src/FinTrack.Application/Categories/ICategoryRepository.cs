using FinTrack.Domain.Entities;

namespace FinTrack.Application.Categories
{
    public interface ICategoryRepository
    {

        public Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task AddAsync(Category category, CancellationToken ct = default);
        public Task UpdateAsync(Category category, CancellationToken ct = default);
    }
}