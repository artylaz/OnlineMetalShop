using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;

namespace OnlineStore.WebMVC.Models.ClientViewModel.DTO
{
    public class PurchaseHistoryDto
    {
        public int ProductId { get; set; }
        public int AmountProduct { get; set; }
        public DateTime DatePurchase { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}
