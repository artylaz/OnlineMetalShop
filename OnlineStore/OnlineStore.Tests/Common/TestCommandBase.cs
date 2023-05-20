using OnlineStore.Persistence;

namespace OnlineStore.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly OnlineStoreDbContext Context;

        public TestCommandBase()
        {
            Context = OnlineStoreContextFactory.Create();
        }

        public void Dispose()
        {
            OnlineStoreContextFactory.Destroy(Context);
        }
    }
}
