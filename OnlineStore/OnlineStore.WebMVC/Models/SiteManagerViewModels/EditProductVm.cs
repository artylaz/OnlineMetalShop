using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.WebMVC.Models.SiteManagerViewModels
{
    public class EditProductVm
    {
        public List<ProductDto> Products { get; set; }
        public List<CategoryDto> ProductCategories { get; set; }
    }
}
