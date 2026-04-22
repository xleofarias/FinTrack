using MediatR;
using FinTrack.Application.Exceptions;

namespace FinTrack.Application.Transactions.Querys.GetByIdTransactionQuery
{
    public class GetByIdTransactionQueryHandler : IRequestHandler<GetByIdTransactionQuery, TransactionResponse>
    {
        private readonly ITransactionRepository _repo;

        public GetByIdTransactionQueryHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task<TransactionResponse> Handle(GetByIdTransactionQuery request, CancellationToken ct)
        {
            var transaction = await _repo.GetByIdAsync(request.Id, ct);

            if (transaction == null)
                throw new NotFoundException($"Transaction with id {request.Id} not found.");

            return new TransactionResponse
            {
                Id = transaction.Id,
                Money = transaction.Amount,
                Description = transaction.Description,
                Date = transaction.Date,
                Type = transaction.Type,
                CategoryId = transaction.CategoryId
            };
        }
    }
}