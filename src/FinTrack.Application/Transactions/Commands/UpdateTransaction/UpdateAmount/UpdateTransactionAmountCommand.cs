using FinTrack.Domain.ValueObjects;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateAmount
{
    public class UpdateTransactionAmountCommand(Guid id, Money money) : IRequest
    {
        public Guid Id { get; private set; } = id;
        public Money Money { get; private set; } = money;
    }
}
