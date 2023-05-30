using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;

namespace OnlineStore.Application.Interfaces
{
    public interface IOnlineStoreDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Characteristic> Characteristics { get; set; }
        DbSet<PriceChange> PriceChanges { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Delivery> Deliveries { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
