using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Commands.UpdateCategory;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Commands.UpdareCategory
{
    public class UpdateCategoryCommandHandler :
        IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public UpdateCategoryCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =
                await dbContext.Categories
                .FirstOrDefaultAsync(c =>
                    c.Id == request.Id, cancellationToken);

            if (category == null)
                throw new NotFoundException(nameof(Category), request.Id);

            category.CategoryId = request.CategoryId;
            category.Name = request.Name;
            category.IsHidden = request.IsHidden;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
