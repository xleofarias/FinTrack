using FinTrack.Domain.Enums;
using FinTrack.Domain.ValueObjects;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand(Money amount, string description, DateTime date, TransactionType type, Guid id) : IRequest<Guid>
    {
        public Money Amount { get; private set; } = amount;
        public string Description { get; private set; } = description;
        public DateTime Date { get; private set; } = date;
        public TransactionType Type { get; private set; } = type;
        public Guid CategoryId { get; private set; } = id;
    }
}
