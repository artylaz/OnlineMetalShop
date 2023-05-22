using MediatR;

namespace OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic
{
    public class DeleteCharacteristicCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
