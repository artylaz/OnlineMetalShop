using FluentValidation;

namespace OnlineStore.Application.Characteristics.Commands.CreateCharacteristic
{
    public class CreateCharacteristicCommandValidator : AbstractValidator<CreateCharacteristicCommand>
    {
        public CreateCharacteristicCommandValidator()
        {
            RuleFor(ch => ch.Name).NotEmpty().MaximumLength(100);
            RuleFor(ch => ch.Value).NotEmpty().MaximumLength(100);
            RuleFor(ch => ch.ProductId).NotEqual(Guid.Empty);
        }
    }
}
