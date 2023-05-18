using FluentValidation;

namespace OnlineStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryValidator
    : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.CategoryId).NotEqual(Guid.Empty);
        }
    }
}
