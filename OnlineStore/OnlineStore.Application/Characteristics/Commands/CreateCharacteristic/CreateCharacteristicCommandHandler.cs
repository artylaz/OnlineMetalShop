using MediatR;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Characteristics.Commands.CreateCharacteristic
{
    public class CreateCharacteristicCommandHandler
        : IRequestHandler<CreateCharacteristicCommand, Guid>
    {
        private readonly IOnlineStoreDbContext dbContext;
        public CreateCharacteristicCommandHandler(IOnlineStoreDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Guid> Handle(CreateCharacteristicCommand request, CancellationToken cancellationToken)
        {
            var characteristic = new Characteristic
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Value = request.Value,
                ProductId = request.ProductId,
            };
            await dbContext.Characteristics.AddAsync(characteristic, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return characteristic.Id;
        }
    }
}
