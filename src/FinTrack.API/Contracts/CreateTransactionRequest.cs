using FinTrack.Domain.ValueObjects;
using FinTrack.Domain.Enums;

namespace FinTrack.API.Contracts
{
    public class CreateTransactionRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description {get;set;}
        public TransactionType Type {get;set;}
        public Guid CategoryId {get;set;}
    }
}