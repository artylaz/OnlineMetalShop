using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Pictures.Commands.Create
{
    public class CreatePictureCommandHandler
    : IRequestHandler<CreatePictureCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public CreatePictureCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(p=>p.Name == request.ProductName,cancellationToken);

            var picture = new Picture();

            picture.Id = request.Id;
            picture.ProductId = product.Id;
            picture.Path = request.Path;
            picture.Name= request.Name;

            await dbContext.Pictures.AddAsync(picture);
            await dbContext.SaveChangesAsync(cancellationToken);
            
        }
    }
}
