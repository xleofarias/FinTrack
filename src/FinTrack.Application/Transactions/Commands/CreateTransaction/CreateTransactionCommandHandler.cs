using MediatR;
using FinTrack.Domain.Entities;

namespace FinTrack.Application.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _repository;
        public CreateTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // TODO: use Transaction.Create(...) passando os dados do request
            var transaction = Transaction.Create(request.Amount, request.Description, request.Date, request.Type, request.CategoryId);

            // TODO: chame o repositório para persistir
            await _repository.AddAsync(transaction);

            // TODO: retorne o Id da transação criada
            return transaction.Id;
        }
    }
}
