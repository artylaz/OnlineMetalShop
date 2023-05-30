using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Baskets.Queries.ShowBasket.DTO;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Baskets.Queries.ShowBasket
{
    public class ShowBasketQueryHandler : IRequestHandler<ShowBasketQuery, List<BasketDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public ShowBasketQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<BasketDto>> Handle(ShowBasketQuery request, CancellationToken cancellationToken)
        {
            var baskets = await dbContext.Baskets
                .Where(b => b.UserId == request.UserId)
                .Include(b => b.Product)
                .ThenInclude(p => p.Pictures)
                .Include(b => b.Product)
                .ThenInclude(p => p.PriceChanges)
                .ProjectTo<BasketDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return baskets;
        }
    }
}
