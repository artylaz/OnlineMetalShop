using AutoMapper;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Products.Queries.DTO;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsHidden { get; set; }

        public Guid CategoryId { get; set; }

        public List<CharacteristicDto> Characteristics { get; set; } = new();
        public List<PictureDto> Pictures { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>();
        }
    }
}
