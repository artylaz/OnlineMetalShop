using MediatR;

namespace OnlineStore.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<CategoryListVm>
    {
        public Guid? CategoryId { get; set; }
    }
}
