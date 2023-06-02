using MediatR;

namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public List<CreateOrderItem> OrderItems { get; set; } = new();

    }
}
