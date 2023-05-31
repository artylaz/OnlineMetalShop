using MediatR;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket
{
    public class ShowBasketQuery : IRequest<ShowBasketVM>
    {
        public Guid UserId { get; set; }
    }
}
