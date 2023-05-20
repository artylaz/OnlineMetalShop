using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeleteCategoryCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await dbContext.Categories
                .FindAsync(request.Id, cancellationToken);
            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
