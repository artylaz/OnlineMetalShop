using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Orders.Queries.DTO;
using OnlineStore.Domain;

namespace OnlineStore.Application.Orders.Queries.GetOrder
{
    public class OrderVm : IMapWith<Order>
    {
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>();
        }
    }
}
