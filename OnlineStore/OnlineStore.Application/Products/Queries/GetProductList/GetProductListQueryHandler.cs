using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetProductListQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products
                .Where(p => p.CategoryId == request.CategoryId)
                .Include(p => p.PriceChanges)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new ProductListVm { Products = product };

        }
    }
}
