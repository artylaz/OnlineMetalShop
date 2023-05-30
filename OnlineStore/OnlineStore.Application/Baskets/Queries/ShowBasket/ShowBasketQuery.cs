using MediatR;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket
{
    public class ShowBasketQuery : IRequest<List<BasketDto>>
    {
        public Guid UserId { get; set; }
    }
}
