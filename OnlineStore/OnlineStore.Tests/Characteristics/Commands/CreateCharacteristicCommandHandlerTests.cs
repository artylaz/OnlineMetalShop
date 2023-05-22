using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Characteristics.Commands.CreateCharacteristic;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Characteristics.Commands
{
    public class CreateCharacteristicCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCharacteristicCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCharacteristicCommandHandler(Context);
            var characteristicName = "charName";
            var characteristicValue = "charValue";
            // Act
            var characteristicId = await handler.Handle(
                new CreateCharacteristicCommand
                {
                    Name = characteristicName,
                    Value = characteristicValue,
                    ProductId = Guid.Parse("cb4d8479-b427-4841-a352-eaae99ddb9a7")
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(
                await Context.Characteristics.SingleOrDefaultAsync(ch =>
                    ch.Id == characteristicId && ch.Name == characteristicName &&
                    ch.Value == characteristicValue &&
                    ch.ProductId == Guid.Parse("cb4d8479-b427-4841-a352-eaae99ddb9a7")));
        }
    }
}
