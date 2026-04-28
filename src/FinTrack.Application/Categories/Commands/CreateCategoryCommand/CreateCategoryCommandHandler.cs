using MediatR;
using FinTrack.Domain.Entities;

namespace FinTrack.Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repo;

        public CreateCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var category = Category.Create(request.Name, request.Type, request.Color);
            
            await _repo.AddAsync(category, cancellationToken);
            
            return category.Id;
        }
    }
}