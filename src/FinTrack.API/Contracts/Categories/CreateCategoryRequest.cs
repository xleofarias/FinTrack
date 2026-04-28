using FinTrack.Domain.Enums;

namespace FinTrack.API.Contracts.Categories
{
    public class CreateCategoryRequest
    {
        public required string Name { get; set; }
        public required string Color { get; set; }
        public TransactionType Type { get; set; }
    }
}