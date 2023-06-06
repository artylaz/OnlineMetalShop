using AutoMapper;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Pictures.DTO
{
    public class PictureDto : IMapWith<Picture>
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Picture, PictureDto>()
                .ForMember(pictureDto => pictureDto.Id,
                    opt => opt.MapFrom(picture => picture.Id))
                .ForMember(pictureDto => pictureDto.Path,
                    opt => opt.MapFrom(picture => picture.Path))
                .ForMember(pictureDto => pictureDto.ProductName,
                    opt => opt.MapFrom(picture => picture.Product.Name));
        }
    }
}
