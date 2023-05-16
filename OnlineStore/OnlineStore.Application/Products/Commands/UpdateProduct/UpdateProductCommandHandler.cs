using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler :
        IRequestHandler<UpdateProductCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public UpdateProductCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product =
                await dbContext.Products
                .Include(p => p.PriceChanges)
                .FirstOrDefaultAsync(product =>
                    product.Id == request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            product.CategoryId = request.CategoryId;
            product.CreationDate = DateTime.Now;
            product.Description = request.Description;
            product.Name = request.Name;
            product.IsHidden = request.IsHidden;

            if (!product.PriceChanges.Any(pr => pr.NewPrice == request.Price))
                product.PriceChanges.Add(new PriceChange
                {
                    NewPrice = request.Price,
                    DatePriceChange = DateTime.Now
                });

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
