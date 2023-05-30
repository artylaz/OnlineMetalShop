using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket.DTO
{
    public class BasketDto : IMapWith<Basket>
    {
        public ProductDto Product { get; set; } = null!;
        public int AmountProduct { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Basket, BasketDto>()
                .ForMember(bDto => bDto.Product,
                    opt => opt.MapFrom(b => b.Product))
                .ForMember(bDto => bDto.AmountProduct,
                    opt => opt.MapFrom(b => b.AmountProduct));

        }
    }
}
