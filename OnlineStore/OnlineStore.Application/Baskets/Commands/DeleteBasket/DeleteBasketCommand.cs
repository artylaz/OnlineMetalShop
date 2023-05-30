using MediatR;

namespace OnlineStore.Application.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
