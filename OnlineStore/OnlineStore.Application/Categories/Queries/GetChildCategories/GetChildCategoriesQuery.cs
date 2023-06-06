using MediatR;
using OnlineStore.Application.Categories.Queries.GetCategoryList;

namespace OnlineStore.Application.Categories.Queries.GetChildCategories
{
    public class GetChildCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
