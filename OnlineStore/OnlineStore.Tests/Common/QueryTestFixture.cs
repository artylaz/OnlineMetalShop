using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Application.Interfaces;
using OnlineStore.Persistence;
using Xunit;

namespace OnlineStore.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public OnlineStoreDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = OnlineStoreContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IOnlineStoreDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            OnlineStoreContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
