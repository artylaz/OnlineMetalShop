using MediatR;
using OnlineStore.Application.Categories.Queries.GetCategoryList;

namespace OnlineStore.Application.Categories.Queries.GetParentCategories
{
    public class GetParentCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
