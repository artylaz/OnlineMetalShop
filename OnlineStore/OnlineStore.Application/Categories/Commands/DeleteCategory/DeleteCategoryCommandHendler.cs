using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHendler
        : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeleteCategoryCommandHendler(IOnlineStoreDbContext dbContext)
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
