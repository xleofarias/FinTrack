using MediatR;
using FinTrack.Application.Exceptions;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateAmount
{
    public class UpdateTransactionAmountCommandHandler : IRequestHandler<UpdateTransactionAmountCommand>
    {
        private readonly ITransactionRepository _repo;
        
        public UpdateTransactionAmountCommandHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateTransactionAmountCommand request, CancellationToken ct)
        {
            var transaction = await _repo.GetByIdAsync(request.Id, ct);

            if (transaction is null) throw new NotFoundException("Transação não encontrada");

            transaction.UpdateAmount(request.Money);

            await _repo.UpdateAsync(transaction, ct);
        }
    }
}