using OnlineStore.Application.Categories.Commands.DeleteCategory;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Categories.Commands
{
    public class DeleteCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCategoryCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCategoryCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCategoryCommand
            {
                Id = OnlineStoreContextFactory.CategoryIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Categories.SingleOrDefault(c =>
                c.Id == OnlineStoreContextFactory.CategoryIdForDelete));
        }

        [Fact]
        public async Task DeleteCategoryCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCategoryCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCategoryCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
