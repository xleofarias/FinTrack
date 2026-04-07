using FinTrack.Domain.Enums;
using FinTrack.Domain.ValueObjects;

namespace FinTrack.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand
    {
        public Money Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public TransactionType Type { get; private set; }
        public Guid CategoryId { get; private set; }
    }
}
