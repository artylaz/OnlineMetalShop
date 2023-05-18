using FluentValidation;

namespace OnlineStore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Id).NotEqual(Guid.Empty);
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
