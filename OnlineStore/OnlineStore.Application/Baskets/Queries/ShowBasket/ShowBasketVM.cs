using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket
{
    public class ShowBasketVM
    {
        public List<BasketDto> Baskets { get; set; }

        public decimal TotalPrice
        {
            get
            {
                if (Baskets != null)
                {
                    decimal totalPrice = 0;
                    foreach (var item in Baskets)
                    {
                        if (item.Product != null)
                            totalPrice += (item.Product.Price * item.AmountProduct);
                    }
                    return totalPrice;
                }
                return 0;
            }
        }
    }
}
