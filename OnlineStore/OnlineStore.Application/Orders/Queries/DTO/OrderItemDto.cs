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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderItem, OrderItemDto>();

        }
    }
}
