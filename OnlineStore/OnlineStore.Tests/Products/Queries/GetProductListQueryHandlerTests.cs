using AutoMapper;
using OnlineStore.Application.Products.Queries.GetProductList;
using OnlineStore.Persistence;
using OnlineStore.Tests.Common;
using Shouldly;
using Xunit;

namespace OnlineStore.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductListQueryHandlerTests
    {
        private readonly OnlineStoreDbContext Context;
        private readonly IMapper Mapper;

        public GetProductListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        //[Fact]
        //public async Task GetProductListQueryHandler_Success()
        //{
        //    // Arrange
        //    var handler = new GetProductListQueryHandler(Context, Mapper);

        //    // Act
        //    var result = await handler.Handle(
        //        new GetProductListQuery
        //        {
        //            CategoryId = Guid.Parse("3769f694-7a5a-47eb-bdb1-62d5c36274d0")
        //        },
        //        CancellationToken.None);

        //    // Assert
        //    result.ShouldBeOfType<ProductListVm>();
        //    result.Products.Count.ShouldBe(2);
        //}
    }
}
