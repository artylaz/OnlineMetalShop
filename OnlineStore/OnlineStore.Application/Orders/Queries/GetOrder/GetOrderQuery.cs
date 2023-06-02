using MediatR;

namespace OnlineStore.Application.Orders.Queries.GetOrder
{
    public class GetOrderQuery:IRequest<OrderVm>
    {
        public Guid UserId { get; set; }
    }
}
