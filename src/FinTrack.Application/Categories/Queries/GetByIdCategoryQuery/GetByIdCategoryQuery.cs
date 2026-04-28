using MediatR;

namespace FinTrack.Application.Categories.Queries.GetByIdCategoryQuery
{
    public class GetByIdCategoryQuery (Guid id): IRequest<CategoryResponse>
    {
        public Guid Id { get; init; } = id;
    }
}