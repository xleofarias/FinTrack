using MediatR;

namespace FinTrack.Application.Categories.Commands.UpdateNameCategoryCommand
{
    public class UpdateNameCategoryCommand (Guid id, string name): IRequest
    {
        public Guid Id { get; init; } = id;
        public string Name { get; private set; } = name;
    }
}