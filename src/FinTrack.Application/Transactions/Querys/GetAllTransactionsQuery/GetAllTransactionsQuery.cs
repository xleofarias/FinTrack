using MediatR;

namespace FinTrack.Application.Transactions.Querys
{
    public class GetAllTransactionsQuery() : IRequest<IEnumerable<TransactionResponse>>
    {
        
    }
}
