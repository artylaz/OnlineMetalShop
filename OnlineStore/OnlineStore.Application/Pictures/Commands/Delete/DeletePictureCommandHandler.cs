using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Pictures.Commands.Delete
{
    public class DeletePictureCommandHandler
    : IRequestHandler<DeletePictureCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeletePictureCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await dbContext.Pictures
                .FindAsync(request.Id, cancellationToken);

            if (picture == null)
                throw new NotFoundException(nameof(Picture), request.Id);

            dbContext.Pictures.Remove(picture);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
