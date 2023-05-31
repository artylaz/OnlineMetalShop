using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket.DTO
{
    public class BasketDto : IMapWith<Basket>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public int AmountProduct { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Basket, BasketDto>()
                .ForMember(bDto => bDto.Product,
                    opt => opt.MapFrom(b => b.Product))
                .ForMember(bDto => bDto.UserId,
                    opt => opt.MapFrom(b => b.UserId))
                .ForMember(bDto => bDto.ProductId,
                    opt => opt.MapFrom(b => b.ProductId))
                .ForMember(bDto => bDto.AmountProduct,
                    opt => opt.MapFrom(b => b.AmountProduct));

        }
    }
}
