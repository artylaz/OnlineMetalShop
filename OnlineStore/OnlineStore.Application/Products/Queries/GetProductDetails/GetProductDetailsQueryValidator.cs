using FluentValidation;
namespace OnlineStore.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryValidator
        : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
