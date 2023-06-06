using MediatR;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Products.Queries.DTO;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO;

namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts
{
    public class FilterSortPaginQuery : IRequest<ShowProductsVm>
    {
        public CategoryHeaderDto Category { get; set; }
        public List<ProductDto> Products { get; set; } = new();
        public List<CharacteristicDto> CheckedCharacteristics { get; set; } = new();
        public string PriceFilter { get; set; } = "1000 P - 3000 P";
        public SortState SortOrder { get; set; } = SortState.NameAsc;
        public int Page { get; set; } = 1;
    }
}
