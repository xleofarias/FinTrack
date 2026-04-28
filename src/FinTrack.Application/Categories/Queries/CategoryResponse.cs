using System.Transactions;
using FinTrack.Domain.Enums;

namespace FinTrack.Application.Categories.Queries
{
    public class CategoryResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Color { get; init; }
        public TransactionType Type { get; init; }
    }
}