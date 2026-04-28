using MediatR;

namespace FinTrack.Application.Categories.Commands.UpdateColorCategoryCommand
{
    public class UpdateColorCategoryCommand (Guid id, string color): IRequest
    {
        public Guid Id { get; init; } = id;
        public string Color { get; private set; } = color;
    }
}