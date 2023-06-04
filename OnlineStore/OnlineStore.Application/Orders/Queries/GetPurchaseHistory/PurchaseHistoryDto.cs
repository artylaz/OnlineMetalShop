using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;

namespace OnlineStore.Application.Orders.Queries.GetPurchaseHistory
{
    public class PurchaseHistoryDto
    {
        public Guid ProductId { get; set; }
        public int AmountProduct { get; set; }
        public DateTime DatePurchase { get; set; }
        public decimal OrderItemPrice { get; set; }
        public ProductDto Product { get; set; } = null!;
    }
}
