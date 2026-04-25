using FinTrack.Domain.Enums;

namespace FinTrack.API.Contracts
{
    public class CreateTransactionRequest
    {
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
        public required string Description {get;set;}
        public TransactionType Type {get;set;}
        public Guid CategoryId {get;set;}
    }
}