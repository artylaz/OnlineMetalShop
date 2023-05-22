using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic
{
    public class DeleteCharacteristicCommandHandler 
        : IRequestHandler<DeleteCharacteristicCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public DeleteCharacteristicCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(DeleteCharacteristicCommand request, 
            CancellationToken cancellationToken)
        {
            var characteristic = await dbContext.Characteristics
                .FindAsync(request.Id, cancellationToken);
            if (characteristic == null)
                throw new NotFoundException(nameof(Characteristic), request.Id);

            dbContext.Characteristics.Remove(characteristic);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
