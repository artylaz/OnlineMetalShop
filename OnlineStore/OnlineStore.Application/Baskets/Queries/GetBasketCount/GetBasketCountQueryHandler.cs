using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Baskets.Queries.GetBasketCount
{
    public class GetBasketCountQueryHandler : IRequestHandler<GetBasketCountQuery, int>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public GetBasketCountQueryHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<int> Handle(GetBasketCountQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Baskets
                .Where(b=>b.UserId ==request.UserId)
                .CountAsync(cancellationToken);
        }
    }
}
