using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Domain;

namespace OnlineStore.WebMVC.Models.SiteManagerViewModels
{
    public class EditCategoryVm
    {
        public List<CategoryDto> Categories { get; set; } = new();
        public List<CategoryDto> ParentCategories { get; set; } = new();
    }
}
