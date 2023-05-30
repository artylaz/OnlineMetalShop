using MediatR;

namespace OnlineStore.Application.Baskets.Commands.AddToBasket
{
    public class AddToBasketCommand : IRequest<(Guid UserId, Guid productId)>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int AmountProduct { get; set; }
    }
}
