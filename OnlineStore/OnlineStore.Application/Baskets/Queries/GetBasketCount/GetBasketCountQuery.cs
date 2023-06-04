using MediatR;

namespace OnlineStore.Application.Baskets.Queries.GetBasketCount
{
    public class GetBasketCountQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
    }
}
