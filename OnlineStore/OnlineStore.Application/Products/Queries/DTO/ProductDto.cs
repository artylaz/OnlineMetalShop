using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Queries.DTO
{
    public class ProductDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsHidden { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(productDto => productDto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.IsHidden,
                    opt => opt.MapFrom(product => product.IsHidden))
                .ForMember(productDto => productDto.Price,
                    opt => opt.MapFrom(product => product.PriceChanges.Max(pr=>pr.NewPrice)));
        }
    }
}
