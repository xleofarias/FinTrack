using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionDescriptionCommandHandler : IRequestHandler<UpdateTransactionDescriptionCommand, string>
    {
        private readonly ITransactionRepository _repository;

        public UpdateTransactionDescriptionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(UpdateTransactionDescriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
