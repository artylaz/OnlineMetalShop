using MediatR;

namespace OnlineStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsHidden { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
