using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Products.Queries.DTO;
using OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO;

namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts
{
    public class ShowProductsVm
    {
        public List<ProductDto> Products { get; set; }
        public CategoryHeaderDto Category { get; set; }
        public List<CharacteristicDto> Characteristics { get; set; }
        public List<CharacteristicDto> CheckedCharacteristics { get; set; }
        public string PriceFilter { get; set; } = null!;
        public SortState SortOrder { get; set; }
        public Page Page { get; set; }
        public Sort Sort { get; set; }
        public int CoutProduct { get; set; }
    }
}
