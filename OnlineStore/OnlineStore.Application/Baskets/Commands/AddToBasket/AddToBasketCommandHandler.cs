using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Baskets.Commands.AddToBasket
{
    public class AddToBasketCommandHandler
    : IRequestHandler<AddToBasketCommand, (CategoryHeaderDto category, int countBasket)>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public AddToBasketCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;


        public async Task<(CategoryHeaderDto category, int countBasket)> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
        {
            var productBasket = await dbContext.Baskets
                .FirstOrDefaultAsync(pb => pb.ProductId == request.ProductId &&
                pb.UserId == request.UserId, cancellationToken);

            if (productBasket == null)
                productBasket = new Basket
                {
                    ProductId = request.ProductId,
                    UserId = request.UserId,
                    AmountProduct = request.AmountProduct,
                };
            else
                productBasket.AmountProduct += request.AmountProduct;

            await dbContext.Baskets.AddAsync(productBasket, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var countBasket = await dbContext.Baskets
                .Where(b => b.UserId == request.UserId)
                .CountAsync();

            var product = await dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == request.ProductId);

            var category = new CategoryHeaderDto
            {
                Id = product.Category.Id,
                Name = product.Category.Name,
                CategoryId = product.Category.CategoryId,
            };

            return (category, countBasket);
        }
    }
}
