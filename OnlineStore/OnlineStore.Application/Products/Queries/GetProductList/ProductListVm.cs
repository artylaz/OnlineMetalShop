using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public List<ProductDto> Products { get; set; } = new();
    }
}
