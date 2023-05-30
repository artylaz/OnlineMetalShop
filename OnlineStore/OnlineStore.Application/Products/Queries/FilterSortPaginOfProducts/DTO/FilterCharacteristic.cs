using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO
{
    public class FilterCharacteristic
    {
        public string NameFilter { get; set; }
        public List<string> Values{ get; set; } = new();
    }
}
