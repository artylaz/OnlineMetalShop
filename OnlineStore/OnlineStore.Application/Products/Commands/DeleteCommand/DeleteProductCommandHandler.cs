using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.DeleteCommand
{
    public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeleteProductCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products
                .FindAsync(request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
