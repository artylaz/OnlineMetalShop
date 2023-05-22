using MediatR;

namespace OnlineStore.Application.Characteristics.Commands.CreateCharacteristic
{
    public class CreateCharacteristicCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public Guid ProductId { get; set; }
    }
}
