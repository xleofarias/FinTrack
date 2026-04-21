using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateDescription
{
    public class UpdateTransactionDescriptionCommand(Guid id, string description) : IRequest
    {
        public Guid Id { get; private set; } = id;
        public string Description { get; private set; } = description;
    }
}
