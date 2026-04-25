using FinTrack.API.Contracts;
using FinTrack.Application.Transactions.Commands.CreateTransaction;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateAmount;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateDescription;
using FinTrack.Application.Transactions.Querys;
using FinTrack.Application.Transactions.Querys.GetByIdTransactionQuery;
using FinTrack.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            var query = new GetAllTransactionsQuery();

            var transactions = await _mediator.Send(query, ct);

            return Ok(transactions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct = default)
        {
            var query = new GetByIdTransactionQuery(id);

            if(query.Id == Guid.Empty)
                return NotFound("Transaction not found.");

            var transaction = await _mediator.Send(query, ct);

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request, CancellationToken ct = default)
        {
            var money = Money.Create(request.Amount, request.Currency);
            var description = request.Description;
            var transactionType = request.Type;
            var categoryId = request.CategoryId;

            var command = new CreateTransactionCommand(money, description, DateTime.UtcNow, transactionType, categoryId);
            
            await _mediator.Send(command, ct);

            return Created();
        }

        [HttpPut("{id:guid}/Amount")]
        public async Task<IActionResult> UpdateAmount(Guid id, UpdateTransactionAmountRequest request, CancellationToken ct = default)
        {
            var money = Money.Create(request.Amount, request.Currency);
            var command = new UpdateTransactionAmountCommand(id, money);

            if(command.Id == Guid.Empty)
                return NotFound();

            await _mediator.Send(command, ct);

            return NoContent();
        }

        [HttpPut("{id:guid}/Description")]
        public async Task<IActionResult> UpdateDescription(Guid id, UpdateTransactionDescriptionRequest request, CancellationToken ct = default)
        {
            var command = new UpdateTransactionDescriptionCommand(id, request.Description);

            if(command.Id == Guid.Empty)
                return NotFound();

            await _mediator.Send(command, ct);

            return NoContent();
        }
    }
}
