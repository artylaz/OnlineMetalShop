using OnlineStore.Application.Orders.Queries.DTO;
using OnlineStore.Application.Users.Queries.GetUser;

namespace OnlineStore.WebMVC.Models.ShoppingModels
{
    public class ShowOrderVm
    {
        public UserVm User { get; set; }
        public decimal ShippingCost { get => 500; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public decimal BasketPrice { get; set; }
        public decimal OrderPrice { get => BasketPrice + ShippingCost; }
    }
}
