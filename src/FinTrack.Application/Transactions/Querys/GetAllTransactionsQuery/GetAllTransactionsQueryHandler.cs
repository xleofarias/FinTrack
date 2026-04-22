using MediatR;

namespace FinTrack.Application.Transactions.Querys
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionResponse>>
    {
        private readonly ITransactionRepository _repo;

        public GetAllTransactionsQueryHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TransactionResponse>> Handle(GetAllTransactionsQuery request, CancellationToken ct)
        {

            var transactions = await _repo.GetAllAsync(ct);

            if (transactions == null || !transactions.Any())
                return Enumerable.Empty<TransactionResponse>();

            return transactions.Select(t => new TransactionResponse
            {
                Id = t.Id,
                Money = t.Amount,
                Description = t.Description,
                Date = t.Date,
                Type = t.Type,
                CategoryId = t.CategoryId
            });
        }
    }
}