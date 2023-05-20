using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Products.Commands.UpdateProduct;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Products.Commands
{
    public class UpdateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateProductCommand
            {
                Id = OnlineStoreContextFactory.ProductIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(product =>
                product.Id == OnlineStoreContextFactory.ProductIdForUpdate &&
                product.Name == updatedName));
        }

        [Fact]
        public async Task UpdateProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProductCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
