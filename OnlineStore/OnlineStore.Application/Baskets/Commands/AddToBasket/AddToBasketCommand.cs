using MediatR;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;

namespace OnlineStore.Application.Baskets.Commands.AddToBasket
{
    public class AddToBasketCommand : IRequest<(CategoryHeaderDto category, int countBasket)>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int AmountProduct { get; set; }
    }
}
