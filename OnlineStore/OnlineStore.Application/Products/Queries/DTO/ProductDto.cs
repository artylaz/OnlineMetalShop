using AutoMapper;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Queries.DTO
{
    public class ProductDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsHidden { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string PathImg { get; set; } = null!;
        public List<CharacteristicDto> Characteristics { get; set; } = new();
        public List<PictureDto> Pictures { get; set; } = new();
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
                    opt => opt.MapFrom(product => product.PriceChanges.Max(pr => pr.NewPrice)))
                .ForMember(productDto => productDto.Characteristics,
                    opt => opt.MapFrom(product => product.Characteristics))
                .ForMember(productDto => productDto.Pictures,
                    opt => opt.MapFrom(product => product.Pictures))
                .ForMember(productDto => productDto.PathImg,
                    opt => opt.MapFrom(product => product.Pictures.First().Path))
                .ForMember(productDto => productDto.Description,
                    opt => opt.MapFrom(product => product.Description))
                .ForMember(productDto => productDto.IsHidden,
                    opt => opt.MapFrom(product => product.IsHidden))
                .ForMember(productDto => productDto.CategoryId,
                    opt => opt.MapFrom(product => product.CategoryId));

        }
    }
}
