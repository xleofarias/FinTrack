using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionDescriptionCommandHandler : IRequestHandler<UpdateTransactionDescriptionCommand, string>
    {
        private readonly ITransactionRepository _repository;

        public UpdateTransactionDescriptionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateTransactionDescriptionCommand request, CancellationToken ct = default)
        {
            var transaction = await _repository.GetTransactionById(request.Id, ct);

            transaction.UpdateDescription(request.Description);

            await _repository.UpdateDescription(transaction, ct);

            return transaction.Description;
        }
    }
}
