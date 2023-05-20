using MediatR;

namespace OnlineStore.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public bool IsHidden { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
