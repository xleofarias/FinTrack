using MediatR;

namespace FinTrack.Application.Categories.Commands.UpdateColorCategoryCommand
{
    public class UpdateColorCategoryCommandHandler : IRequestHandler<UpdateColorCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public UpdateColorCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateColorCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
                throw new KeyNotFoundException("Category not found.");

            category.UpdateColor(request.Color);
            await _repo.UpdateAsync(category, cancellationToken);
        }
    }
}