using AutoMapper;
using OnlineStore.Application.Products.Queries.GetProductDetails;
using OnlineStore.Persistence;
using OnlineStore.Tests.Common;
using Shouldly;
using Xunit;

namespace OnlineStore.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductDetailsQueryHandlerTests
    {
        private readonly OnlineStoreDbContext Context;
        private readonly IMapper Mapper;

        public GetProductDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProductDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetProductDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetProductDetailsQuery
                {
                    Id = Guid.Parse("ce64e418-f507-465b-926e-09f77c764e47")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ProductDetailsVm>();
            result.Name.ShouldBe("Name3");
            result.IsHidden.ShouldBe(true);
            result.Price.ShouldBe(10200);
            result.Description.ShouldBe("Description3");
            result.Pictures.Count.ShouldBe(0);
            result.Characteristics.Count.ShouldBe(0);
            result.CreationDate.Day.ShouldBe(DateTime.Today.Day);
        }
    }
}
