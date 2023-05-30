using MediatR;
using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductDto>>
    {
        public Guid? CategoryId { get; set; }
    }
}
