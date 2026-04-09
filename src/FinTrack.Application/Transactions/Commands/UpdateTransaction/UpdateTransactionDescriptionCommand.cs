using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionDescriptionCommand(Guid id, string description) : IRequest<string>
    {
        public Guid Id { get; private set; } = id;
        public string Description { get; private set; } = description;
    }
}
