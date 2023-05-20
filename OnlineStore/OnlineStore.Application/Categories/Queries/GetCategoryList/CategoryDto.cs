using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Queries.GetCategoryList
{
    public class CategoryDto : IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsHidden { get; set; }

        public Guid? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>();
        }
    }
}
