using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Queries.GetCategoryHeaderList
{
    public class CategoryHeaderDto : IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public bool IsHidden { get; set; }
        public List<CategoryHeaderDto> CategoryHeaders { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryHeaderDto>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Name,
                opt => opt.MapFrom(c => c.Name))
                .ForMember(dto => dto.CategoryId,
                opt => opt.MapFrom(c => c.CategoryId))
                .ForMember(dto => dto.IsHidden,
                opt => opt.MapFrom(c => c.IsHidden))
                .ForMember(dto => dto.CategoryHeaders,
                opt => opt.MapFrom(c => c.InverseCategoryNavigation));
        }
    }
}
