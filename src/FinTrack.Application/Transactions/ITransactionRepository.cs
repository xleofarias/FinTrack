using FinTrack.Domain.Entities;

namespace FinTrack.Application.Transactions
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionById(Guid id, CancellationToken ct = default);
        Task AddAsync(Transaction transaction, CancellationToken ct = default);
        Task UpdateDescription(Transaction transaction, CancellationToken ct = default);
    }
          //● JSON (HTTP Request)
          //      ↓
          //Controller  →  instancia o CreateTransactionCommand
          //      ↓
          //MediatR  →  encontra o CreateTransactionCommandHandler
          //      ↓
          //Handler  →  chama Transaction.Create(...) com os dados do command
          //      ↓
          //ITransactionRepository.AddAsync(transaction)  →  persiste no banco
          //      ↓
          //Retorna o Guid da transação criada
          //      ↓
          //Controller  →  responde o cliente com 201 Created + Guid
}
