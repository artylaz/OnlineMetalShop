using FluentValidation;

namespace OnlineStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdareCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdareCategoryCommandValidator()
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
