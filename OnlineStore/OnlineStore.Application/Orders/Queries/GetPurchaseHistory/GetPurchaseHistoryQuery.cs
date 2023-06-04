using MediatR;

namespace OnlineStore.Application.Orders.Queries.GetPurchaseHistory
{
    public class GetPurchaseHistoryQuery : IRequest<List<PurchaseHistoryDto>>
    {
        public Guid UserId { get; set; }
    }
}
