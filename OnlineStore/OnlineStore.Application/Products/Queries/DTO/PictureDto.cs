using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Queries.DTO
{
    public class PictureDto : IMapWith<Picture>
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Picture, PictureDto>();
        }
    }
}
