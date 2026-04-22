using MediatR;

namespace FinTrack.Application.Transactions.Querys.GetByIdTransactionQuery
{
    public class GetByIdTransactionQuery (Guid id): IRequest<TransactionResponse>
    {
        public Guid Id { get; init; } = id;
    }
}