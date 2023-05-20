using AutoMapper;
using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Persistence;
using OnlineStore.Tests.Common;
using Shouldly;
using Xunit;

namespace OnlineStore.Tests.Categories.Queries
{
    [Collection("QueryCollection")]
    public class GetCategoryListQueryHandlerTests
    {
        private readonly OnlineStoreDbContext Context;
        private readonly IMapper Mapper;

        public GetCategoryListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCategoryListQueryHandlerWithoutCategoryId_Success()
        {
            // Arrange
            var handler = new GetCategoryListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCategoryListQuery
                {
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CategoryListVm>();
            result.Categories.Count.ShouldBe(4);
        }

        [Fact]
        public async Task GetCategoryListQueryHandlerWithCategoryId_Success()
        {
            // Arrange
            var handler = new GetCategoryListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCategoryListQuery
                {
                    CategoryId = OnlineStoreContextFactory.CategoryIdForDelete
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CategoryListVm>();
            result.Categories.Count.ShouldBe(1);
        }
    }
}
