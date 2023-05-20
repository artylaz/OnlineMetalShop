using FluentValidation;

namespace OnlineStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Name).NotEmpty().MaximumLength(80);
            RuleFor(createProductCommand =>
            createProductCommand.Description).NotEmpty().MaximumLength(2000);
            RuleFor(createProductCommand =>
            createProductCommand.Price).NotEmpty();
            RuleFor(createProductCommand =>
            createProductCommand.IsHidden).NotEmpty();
            RuleFor(createProductCommand =>
            createProductCommand.CategoryId).NotEqual(Guid.Empty);
        }
    }
}
