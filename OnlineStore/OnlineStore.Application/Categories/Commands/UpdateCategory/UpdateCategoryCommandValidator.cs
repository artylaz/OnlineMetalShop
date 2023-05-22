using FluentValidation;

namespace OnlineStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createProductCommand =>
            createProductCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createProductCommand =>
            createProductCommand.IsHidden).NotEmpty();
        }
    }
}
