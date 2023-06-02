using OnlineStore.WebMVC.Models.ClientViewModel.DTO;

namespace OnlineStore.WebMVC.Models.ClientViewModel
{
    public class MyAccountVM
    {
        public List<PurchaseHistoryDto> PurchaseHistories { get; set; }
        public UserAccountDto User { get; set; }

        public decimal GetPrice(int amountProduct, decimal price)
        {
            return price * amountProduct;
        }
    }
}
