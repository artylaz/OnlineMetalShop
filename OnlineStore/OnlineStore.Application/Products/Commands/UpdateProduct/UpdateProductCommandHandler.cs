using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler :
        IRequestHandler<UpdateProductCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateProductCommandHandler(IOnlineStoreDbContext dbContext,
            IMapper mapper) => (this.dbContext, this.mapper) = (dbContext, mapper);
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product =
                await dbContext.Products
                .Include(p => p.Characteristics)
                .Include(p => p.Pictures)
                .Include(p => p.PriceChanges)
                .FirstOrDefaultAsync(product =>
                    product.Id == request.Id, cancellationToken);

            product ??= new Product();

            product.CategoryId = request.CategoryId;
            product.CreationDate = DateTime.Now;
            product.Description = request.Description;
            product.Name = request.Name;
            product.IsHidden = request.IsHidden;
            product.Characteristics = mapper.Map<List<Characteristic>>(request.Characteristics);
            if (!product.PriceChanges.Any(pr => pr.NewPrice == request.Price))
                product.PriceChanges.Add(new PriceChange
                {
                    NewPrice = request.Price,
                    DatePriceChange = DateTime.UtcNow,
                });


            if (product.Id == Guid.Empty)
                await dbContext.Products.AddAsync(product, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
