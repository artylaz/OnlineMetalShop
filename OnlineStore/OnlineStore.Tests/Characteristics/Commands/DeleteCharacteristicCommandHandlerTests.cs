using OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Characteristics.Commands
{
    public class DeleteCharacteristicCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCharacteristicCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCharacteristicCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCharacteristicCommand
            {
                Id = OnlineStoreContextFactory.CharacteristicIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Characteristics.SingleOrDefault(ch =>
                ch.Id == OnlineStoreContextFactory.CharacteristicIdForDelete));
        }

        [Fact]
        public async Task DeleteCharacteristicCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCharacteristicCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCharacteristicCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
