using MediatR;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public CreateCategoryCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                IsHidden = request.IsHidden,
                Name = request.Name,
            };
            await dbContext.Categories.AddAsync(category, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
