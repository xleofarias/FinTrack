using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinTrack.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // TODO: use Transaction.Create(...) passando os dados do request
            // TODO: chame o repositório para persistir
            // TODO: retorne o Id da transação criada
            throw new NotImplementedException();
        }

    }
}
