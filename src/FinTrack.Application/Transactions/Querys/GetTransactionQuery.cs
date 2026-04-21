using MediatR;
using System.Transactions;

namespace FinTrack.Application.Transactions.Querys
{
    public class GetTransactionQuery(Guid guid, Transaction transaction) : IRequest<Transaction>
    {
        public Guid Guid { get; private set; } = guid;

        public Transaction Transaction { get; private set; } = transaction;
    }
}
