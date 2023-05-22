using MediatR;

namespace OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic
{
    public class UpdateCharacteristicCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public Guid ProductId { get; set; }
    }
}
