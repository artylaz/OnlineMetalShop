using MediatR;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public Guid CategoryId { get; set; }
    }
}
