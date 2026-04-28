using FinTrack.Application.Exceptions;
using MediatR;

namespace FinTrack.Application.Categories.Queries.GetByIdCategoryQuery
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
    {
        private readonly ICategoryRepository _repo;

        public GetByIdCategoryQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<CategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Color = category.Color,
                Type = category.Type
            };
        }
    }
}