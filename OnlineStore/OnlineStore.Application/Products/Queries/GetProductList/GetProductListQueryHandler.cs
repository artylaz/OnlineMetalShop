using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetProductListQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = new List<ProductDto>();

            var category = await dbContext.Categories
                .Include(c => c.InverseCategoryNavigation)
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);

            if (request.CategoryId == null || category == null)
            {
                products = await dbContext.Products
                .Include(p => p.PriceChanges)
                .Include(p => p.Pictures)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return products;
            }

            if (category.CategoryId == null)
            {
                foreach (var item in category.InverseCategoryNavigation)
                {
                    var findProducts = await dbContext.Products
                        .Where(p => p.CategoryId == item.Id)
                        .Include(p => p.PriceChanges)
                        .Include(p => p.Pictures)
                        .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    products.AddRange(findProducts);
                }
            }
            else
                products = await dbContext.Products
                    .Where(p => p.CategoryId == request.CategoryId)
                    .Include(p => p.PriceChanges)
                    .Include(p => p.Pictures)
                    .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return products;

        }
    }
}
