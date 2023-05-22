using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic
{
    public class UpdateCharacteristicCommandHandler
        : IRequestHandler<UpdateCharacteristicCommand>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public UpdateCharacteristicCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task Handle(UpdateCharacteristicCommand request, CancellationToken cancellationToken)
        {
            var characteristic =
                await dbContext.Characteristics
                .FirstOrDefaultAsync(ch =>
                    ch.Id == request.Id, cancellationToken);

            if (characteristic == null)
                throw new NotFoundException(nameof(Characteristic), request.Id);

            characteristic.Name = request.Name;
            characteristic.Value = request.Value;
            characteristic.ProductId = request.ProductId;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
