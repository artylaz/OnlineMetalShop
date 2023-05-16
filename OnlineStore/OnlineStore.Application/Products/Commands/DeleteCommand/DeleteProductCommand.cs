using MediatR;

namespace OnlineStore.Application.Products.Commands.DeleteCommand
{
    public class DeleteProductCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
