using AutoMapper;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Orders.Queries.DTO
{
    public class OrderItemDto : IMapWith<OrderItem>
    {
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal OrderItemPrice { get => ProductPrice * ProductCount; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>();
            profile.CreateMap<BasketDto, OrderItemDto>()
                .ForMember(or => or.Product,
                    opt => opt.MapFrom(b => b.Product))
                .ForMember(or => or.ProductPrice,
                    opt => opt.MapFrom(b => b.Product.Price))
                .ForMember(or => or.ProductCount,
                    opt => opt.MapFrom(b => b.AmountProduct))
                .ForMember(or => or.ProductId,
                    opt => opt.MapFrom(b => b.ProductId));
        }
    }
}
