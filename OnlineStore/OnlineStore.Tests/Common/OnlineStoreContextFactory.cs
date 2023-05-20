using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;
using OnlineStore.Persistence;

namespace OnlineStore.Tests.Common
{
    public class OnlineStoreContextFactory
    {
        public static Guid CategoryIdForDelete = Guid.NewGuid();
        public static Guid CategoryIdForUpdate = Guid.NewGuid();

        public static Guid ProductIdForDelete = Guid.NewGuid();
        public static Guid ProductIdForUpdate = Guid.NewGuid();

        public static OnlineStoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OnlineStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new OnlineStoreDbContext(options);
            context.Database.EnsureCreated();

            context.Categories.AddRange(
                new Category
                {
                    Id = CategoryIdForDelete,
                    Name = "Name1",
                    IsHidden = true,
                    CategoryId = null,
                },
                new Category
                {
                    Id = Guid.Parse("93e6ea1b-1743-478b-9fec-351a4a7e6d08"),
                    Name = "Name1_1",
                    IsHidden = true,
                    CategoryId = CategoryIdForDelete,
                },

                new Category
                {
                    Id = CategoryIdForUpdate,
                    Name = "Name2",
                    IsHidden = true,
                    CategoryId = null,
                },
                new Category
                {
                    Id = Guid.Parse("3769f694-7a5a-47eb-bdb1-62d5c36274d0"),
                    Name = "Name2_1",
                    IsHidden = true,
                    CategoryId = CategoryIdForUpdate,
                });

            context.Products.AddRange(
                new Product
                {
                    Id = Guid.Parse("cb4d8479-b427-4841-a352-eaae99ddb9a7"),
                    CategoryId = Guid.Parse("93e6ea1b-1743-478b-9fec-351a4a7e6d08"),
                    CreationDate = DateTime.UtcNow,
                    Name = "Name1",
                    IsHidden = true,
                    Description = "Description1",
                    PriceChanges = new List<PriceChange>
                    {
                        new PriceChange{ NewPrice = 71000, DatePriceChange = DateTime.UtcNow}
                    }
                },
                new Product
                {
                    Id = ProductIdForDelete,
                    CategoryId = Guid.Parse("93e6ea1b-1743-478b-9fec-351a4a7e6d08"),
                    CreationDate = DateTime.UtcNow,
                    Name = "Name2",
                    IsHidden = true,
                    Description = "Description2",
                    PriceChanges = new List<PriceChange>
                    {
                        new PriceChange{ NewPrice = 21000, DatePriceChange = DateTime.UtcNow}
                    }
                },

                new Product
                {
                    Id = Guid.Parse("ce64e418-f507-465b-926e-09f77c764e47"),
                    CategoryId = Guid.Parse("3769f694-7a5a-47eb-bdb1-62d5c36274d0"),
                    CreationDate = DateTime.UtcNow,
                    Name = "Name3",
                    IsHidden = true,
                    Description = "Description3",
                    PriceChanges = new List<PriceChange>
                    {
                        new PriceChange{ NewPrice = 10200, DatePriceChange = DateTime.UtcNow}
                    }
                },
                new Product
                {
                    Id = ProductIdForUpdate,
                    CategoryId = Guid.Parse("3769f694-7a5a-47eb-bdb1-62d5c36274d0"),
                    CreationDate = DateTime.UtcNow,
                    Name = "Name4",
                    IsHidden = true,
                    Description = "Description4",
                    PriceChanges = new List<PriceChange>
                    {
                        new PriceChange{ NewPrice = 10010, DatePriceChange = DateTime.UtcNow}
                    }
                });

            context.SaveChanges();
            return context;
        }
        public static void Destroy(OnlineStoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
