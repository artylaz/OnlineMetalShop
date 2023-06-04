using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Orders.Queries.DTO;
using OnlineStore.Domain;

namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderItem : IMapWith<OrderItem>
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderItem, OrderItem>();
            profile.CreateMap<OrderItemDto, CreateOrderItem>();
        }
    }
}
