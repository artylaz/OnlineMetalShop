using FluentValidation;

namespace OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic
{
    public class DeleteCharacteristicCommandValidator
        : AbstractValidator<DeleteCharacteristicCommand>
    {
        public DeleteCharacteristicCommandValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
    }
}
