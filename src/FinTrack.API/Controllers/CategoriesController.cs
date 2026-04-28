using FinTrack.Application.Categories.Commands.CreateCategoryCommand;
using FinTrack.Application.Categories.Queries.GetByIdCategoryQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinTrack.API.Contracts.Categories;
using FinTrack.Application.Categories.Commands.UpdateNameCategoryCommand;
using FinTrack.Application.Categories.Commands.UpdateColorCategoryCommand;

namespace FinTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByCategoryId(Guid id, CancellationToken ct = default)
        {
            var result = new GetByIdCategoryQuery(id);

            var category = await _mediator.Send(result, ct);
            
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest command, CancellationToken ct = default)
        {
            var name = command.Name;
            var color = command.Color;
            var type = command.Type;

            var createCommand = new CreateCategoryCommand(name, type, color);

            await _mediator.Send(createCommand, ct);

            return Created();
        }

        [HttpPut("{id:guid}/Name")]
        public async Task<IActionResult> UpdateNameCategory(Guid id, [FromBody] UpdateCategoryNameRequest command, CancellationToken ct = default)
        {
            var name = command.Name;

            var updateCommand = new UpdateNameCategoryCommand(id, name);

            await _mediator.Send(updateCommand, ct);

            return NoContent();
        }

        [HttpPut("{id:guid}/Color")]
        public async Task<IActionResult> UpdateColorCategory(Guid id, [FromBody] UpdateCategoryColorRequest command, CancellationToken ct = default)
        {
            var color = command.Color;

            var updateCommand = new UpdateColorCategoryCommand(id, color);

            await _mediator.Send(updateCommand, ct);

            return NoContent();
        }
    }
}