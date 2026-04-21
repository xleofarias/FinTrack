using FinTrack.API.Contracts;
using FinTrack.Application.Transactions.Commands.CreateTransaction;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateAmount;
using FinTrack.Application.Transactions.Commands.UpdateTransaction.UpdateDescription;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionCommand createTransaction, CancellationToken ct = default)
        {
            await _mediator.Send(createTransaction, ct);

            return Created();
        }

        [HttpPut("{id:guid}/Amount")]
        public async Task<IActionResult> UpdateAmount(Guid id, UpdateTransactionAmountRequest request, CancellationToken ct = default)
        {
            var money = Money.Create(request.Amount, request.Currency);
            var command = new UpdateTransactionAmountCommand(id, money);
            await _mediator.Send(command, ct);

            return NoContent();
        }

        [HttpPut("{id:guid}/Description")]
        public async Task<IActionResult> UpdateDescription(Guid id, UpdateTransactionDescriptionRequest request, CancellationToken ct = default)
        {
            var command = new UpdateTransactionDescriptionCommand(id, request.Description);

            await _mediator.Send(command, ct);

            return NoContent();
        }
    }
}
