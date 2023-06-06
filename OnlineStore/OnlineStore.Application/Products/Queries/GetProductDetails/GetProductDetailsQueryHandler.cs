using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Characteristics.DTO;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Products.Queries.DTO;

namespace OnlineStore.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler
        : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetProductDetailsQueryHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products
                .Include(p=>p.PriceChanges)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(product),request.Id);

            var productDetailsVm =
                mapper.Map<ProductDetailsVm>(product);

            productDetailsVm.Price = product.PriceChanges.Max(p => p.NewPrice);

            productDetailsVm.Characteristics = await dbContext.Characteristics
                .Where(p => p.ProductId == request.Id)
                .ProjectTo<CharacteristicDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            productDetailsVm.Pictures = await dbContext.Pictures
                .Where(p => p.ProductId == request.Id)
                .ProjectTo<PictureDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return productDetailsVm;
        }
    }
}
