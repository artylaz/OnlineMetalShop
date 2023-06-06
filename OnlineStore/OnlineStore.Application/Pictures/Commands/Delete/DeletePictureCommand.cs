using MediatR;

namespace OnlineStore.Application.Pictures.Commands.Delete
{
    public class DeletePictureCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
