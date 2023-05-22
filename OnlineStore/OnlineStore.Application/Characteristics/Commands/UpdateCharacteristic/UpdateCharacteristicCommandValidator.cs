using FluentValidation;

namespace OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic
{
    public class UpdateCharacteristicCommandValidator : AbstractValidator<UpdateCharacteristicCommand>
    {
        public UpdateCharacteristicCommandValidator()
        {
            RuleFor(ch => ch.Id).NotEqual(Guid.Empty);
            RuleFor(ch => ch.Name).NotEmpty().MaximumLength(100);
            RuleFor(ch => ch.Value).NotEmpty().MaximumLength(100);
            RuleFor(ch => ch.ProductId).NotEqual(Guid.Empty);
        }
    }
}
