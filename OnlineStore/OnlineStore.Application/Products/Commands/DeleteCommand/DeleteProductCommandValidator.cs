using FluentValidation;

namespace OnlineStore.Application.Products.Commands.DeleteCommand
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
