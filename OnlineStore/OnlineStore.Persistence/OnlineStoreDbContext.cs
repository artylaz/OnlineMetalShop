using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain;
using OnlineStore.Persistence.EntityTypeConfigurations;

namespace OnlineStore.Persistence
{
    public class OnlineStoreDbContext : DbContext, IOnlineStoreDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<PriceChange> PriceChanges { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new PictureConfiguration());
            builder.ApplyConfiguration(new CharacteristicConfiguration());
            builder.ApplyConfiguration(new PriceChangeConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BasketConfiguration());

            Role clientRole = new()
            {
                Id = Guid.NewGuid(),
                Name = "Client"
            };
            Role siteManagerRole = new()
            {
                Id = Guid.NewGuid(),
                Name = "SiteManager"
            };
            Role orderManagerRole = new()
            {
                Id = Guid.NewGuid(),
                Name = "OrderManager"
            };
            User siteManagerUser = new()
            {
                Id = Guid.NewGuid(),
                RoleId = siteManagerRole.Id,
                Email = "sitemanager@mail.ru",
                Password = "sitemanager",
                RegistrationDate = DateTime.UtcNow,
                FirstName = "FirstName",
                LastName = "LastName",
                IsAccess = true,
                Phone = "+79998887766",
            };
            User orderManagerUser = new()
            {
                Id = Guid.NewGuid(),
                RoleId = orderManagerRole.Id,
                Email = "ordermanager@mail.ru",
                Password = "ordermanager",
                RegistrationDate = DateTime.UtcNow,
                FirstName = "FirstName",
                LastName = "LastName",
                IsAccess = true,
                Phone = "+79998887766",
            };
            OrderStatus orderStatus = new()
            {
                  Id = Guid.NewGuid(),
                   Name = "Cоздан"
            };
            OrderStatus orderStatus2 = new()
            {
                Id = Guid.NewGuid(),
                Name = "Оплачен"
            };
            OrderStatus orderStatus3 = new()
            {
                Id = Guid.NewGuid(),
                Name = "Отгружен"
            };
            OrderStatus orderStatus4 = new()
            {
                Id = Guid.NewGuid(),
                Name = "Отменен"
            };

            builder.Entity<Role>().HasData(new Role[] { clientRole, siteManagerRole, orderManagerRole });
            builder.Entity<User>().HasData(new User[] { siteManagerUser, orderManagerUser });
            builder.Entity<OrderStatus>().HasData(new OrderStatus[] { orderStatus, orderStatus2, orderStatus3, orderStatus4 });

            base.OnModelCreating(builder);
        }
    }
}
