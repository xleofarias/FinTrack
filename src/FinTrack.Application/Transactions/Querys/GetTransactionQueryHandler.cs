using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;

namespace FinTrack.Application.Transactions.Querys
{
    public class GetTransactionQueryHandler : IRequestHandler<Transaction>
    {
        private readonly ITransactionRepository _repo;

        public GetTransactionQueryHandler(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public Task Handle(Transaction request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
