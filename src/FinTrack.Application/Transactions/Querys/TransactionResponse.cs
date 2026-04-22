using FinTrack.Domain.ValueObjects;
using FinTrack.Domain.Enums;

namespace FinTrack.Application.Transactions.Querys
{
    public class TransactionResponse
    {
        public Guid Id {get;init;}
        public required Money Money {get; init;}
        public required string Description {get; init;}
        public DateTime Date {get; init;}
        public TransactionType Type {get; init;}
        public Guid CategoryId {get; init;}
    }
}