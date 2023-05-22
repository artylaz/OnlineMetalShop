using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Characteristics.Commands
{
    public class UpdateCharacteristicCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task UpdateCharacteristicCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCharacteristicCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateCharacteristicCommand
            {
                Id = OnlineStoreContextFactory.CharacteristicIdForUpdate,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Characteristics.SingleOrDefaultAsync(cat =>
                cat.Id == OnlineStoreContextFactory.CharacteristicIdForUpdate &&
                cat.Name == updatedName));
        }

        [Fact]
        public async Task UpdateCharacteristicCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCharacteristicCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateCharacteristicCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
