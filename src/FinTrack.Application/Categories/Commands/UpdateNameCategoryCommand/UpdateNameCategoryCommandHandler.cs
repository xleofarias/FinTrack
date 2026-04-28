using MediatR;

namespace FinTrack.Application.Categories.Commands.UpdateNameCategoryCommand
{
    public class UpdateNameCategoryCommandHandler : IRequestHandler<UpdateNameCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

            public UpdateNameCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateNameCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
                throw new KeyNotFoundException("Category not found.");

            category.UpdateName(request.Name);
            await _repo.UpdateAsync(category, cancellationToken);
        }
    }
}