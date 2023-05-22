using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Products.Commands.DeleteCommand;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Products.Commands
{
    public class DeleteProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProductCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteProductCommand
            {
                Id = OnlineStoreContextFactory.ProductIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Products.SingleOrDefault(c =>
                c.Id == OnlineStoreContextFactory.ProductIdForDelete));
        }

        [Fact]
        public async Task DeleteProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProductCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
