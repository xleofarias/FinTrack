using FinTrack.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Application.Transactions
{
    public interface ITransactionRepository
    {
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
