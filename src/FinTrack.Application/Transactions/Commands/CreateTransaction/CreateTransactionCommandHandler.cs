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

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken ct = default)
        {
            var transaction = Transaction.Create(request.Amount, request.Description, request.Date, request.Type, request.CategoryId);

            await _repository.AddAsync(transaction);

            return transaction.Id;
        }
    }
}
