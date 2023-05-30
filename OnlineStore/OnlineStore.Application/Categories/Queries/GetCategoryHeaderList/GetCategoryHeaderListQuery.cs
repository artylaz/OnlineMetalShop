using MediatR;

namespace OnlineStore.Application.Categories.Queries.GetCategoryHeaderList
{
    public class GetCategoryHeaderListQuery:IRequest<List<CategoryHeaderDto>>
    {

    }
}
