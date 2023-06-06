using MediatR;

namespace OnlineStore.Application.Pictures.Commands.Create
{
    public class CreatePictureCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;

        public string ProductName { get; set; }
    }
}
