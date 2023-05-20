using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Commands.UpdareCategory;
using OnlineStore.Application.Categories.Commands.UpdateCategory;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Categories.Commands
{
    public class UpdateCategoryCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task UpdateCategoryCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCategoryCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateCategoryCommand
            {
                Id = OnlineStoreContextFactory.CategoryIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Categories.SingleOrDefaultAsync(cat =>
                cat.Id == OnlineStoreContextFactory.CategoryIdForUpdate &&
                cat.Name == updatedName));
        }

        [Fact]
        public async Task UpdateCategoryCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCategoryCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateCategoryCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
