using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Baskets.Commands.AddToBasket
{
    public class AddToBasketCommandHandler
    : IRequestHandler<AddToBasketCommand, (Guid UserId, Guid productId)>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public AddToBasketCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;


        public async Task<(Guid UserId, Guid productId)> IRequestHandler<AddToBasketCommand, (Guid UserId, Guid productId)>.Handle(AddToBasketCommand request, CancellationToken cancellationToken)
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

            await dbContext.SaveChangesAsync(cancellationToken);

            return (productBasket.UserId, productBasket.ProductId);
        }
    }
}
