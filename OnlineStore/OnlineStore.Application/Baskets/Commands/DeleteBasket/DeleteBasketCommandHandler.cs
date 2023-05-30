using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler
    : IRequestHandler<DeleteBasketCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeleteBasketCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var productBasket = await dbContext.Baskets
                .FirstOrDefaultAsync(pb => pb.ProductId == request.ProductId &&
                pb.UserId == request.UserId, cancellationToken);

            if (productBasket == null)
                throw new NotFoundException(nameof(Basket), (request.UserId, request.ProductId));

            dbContext.Baskets.Remove(productBasket);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
