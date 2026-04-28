using FinTrack.Domain.Enums;
using MediatR;

namespace FinTrack.Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand(string name, TransactionType type, string color) : IRequest<Guid>
    {
        public string Name { get; private set; } = name; 
        public TransactionType Type { get; private set; } = type;
        public string Color { get; private set; } = color;
    }
}