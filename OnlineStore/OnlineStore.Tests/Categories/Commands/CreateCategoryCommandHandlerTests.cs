using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Categories.Commands.CreateCategory;
using OnlineStore.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.Tests.Categories.Commands
{
    public class CreateCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCategoryCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCategoryCommandHandler(Context);
            var categoryName = "catName";
            // Act
            var categoryId = await handler.Handle(
                new CreateCategoryCommand
                {
                    Name = categoryName,
                    IsHidden = true,
                },
                CancellationToken.None);
            // Assert
            Assert.NotNull(
                await Context.Categories.SingleOrDefaultAsync(cat =>
                    cat.Id == categoryId && cat.Name == categoryName &&
                    cat.IsHidden == true));
        }
    }
}
