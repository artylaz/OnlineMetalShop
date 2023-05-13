namespace OnlineStore.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(OnlineStoreDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
