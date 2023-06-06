using MediatR;
using OnlineStore.Application.Products.Commands.DTO;

namespace OnlineStore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsHidden { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public List<CharacteristicDto> Characteristics { get; set; } = new();
    }
}
