using OnlineStore.Application.Orders.Queries.GetPurchaseHistory;
using OnlineStore.Application.Users.Queries.GetUser;

namespace OnlineStore.WebMVC.Models.ClientViewModel
{
    public class MyAccountVm
    {
        public List<PurchaseHistoryDto> PurchaseHistories { get; set; }
        public UserVm User { get; set; }
    }
}
