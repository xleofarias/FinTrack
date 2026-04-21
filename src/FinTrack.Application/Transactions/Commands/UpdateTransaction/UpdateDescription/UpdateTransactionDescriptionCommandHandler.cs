using FinTrack.Application.Exceptions;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateDescription
{
    public class UpdateTransactionDescriptionCommandHandler : IRequestHandler<UpdateTransactionDescriptionCommand>
    {
        private readonly ITransactionRepository _repository;

        public UpdateTransactionDescriptionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTransactionDescriptionCommand request, CancellationToken ct = default)
        {
            var transaction = await _repository.GetByIdAsync(request.Id, ct);

            if (transaction is null) throw new NotFoundException("Transação não encontrada");

            transaction.UpdateDescription(request.Description);

            await _repository.UpdateAsync(transaction, ct);
        }
    }
}