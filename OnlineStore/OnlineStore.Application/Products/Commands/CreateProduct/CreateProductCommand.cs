using MediatR;

namespace OnlineStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsHidden { get; set; }

        public Guid CategoryId { get; set; }
    }
}
