using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Products.Commands.CreateProduct;
using OnlineStore.Tests.Common;
using Xunit;

namespace OnlineStore.Tests.Products.Commands
{
    public class CreateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateProductCommandHandler(Context);
            var productName = "product name";
            var productDescription = "product description";
            var productPrice = 120000;

            // Act
            var productId = await handler.Handle(
                new CreateProductCommand
                {
                    CategoryId = OnlineStoreContextFactory.CategoryIdForDelete,
                    Name = productName,
                    Description = productDescription,
                    IsHidden = true,
                    Price = productPrice
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Products
                .Include(p => p.PriceChanges)
                .SingleOrDefaultAsync(product =>
                    product.Id == productId && product.Name == productName &&
                    product.Description == productDescription &&
                    product.PriceChanges.Max(p => p.NewPrice) == productPrice));
        }
    }
}
