using FluentValidation;

namespace OnlineStore.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
            RuleFor(c => c.IsHidden).NotEmpty();
            RuleFor(c => c.CategoryId).NotEqual(Guid.Empty);
        }
    }
}
