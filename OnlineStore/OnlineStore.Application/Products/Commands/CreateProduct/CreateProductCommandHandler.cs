using MediatR;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public CreateProductCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                CreationDate = DateTime.Now,
                Description = request.Description,
                Name = request.Name,
                IsHidden = request.IsHidden
            };
            
            product.PriceChanges.Add(new PriceChange 
            { 
                NewPrice = request.Price, 
                DatePriceChange = DateTime.Now 
            });

            await dbContext.Products.AddAsync(product, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
