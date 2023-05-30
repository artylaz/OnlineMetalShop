namespace OnlineStore.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;
        public Guid StoreId { get; set; }
        public Store Store { get; set; } = null!;
        public DateTime CreationDate { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
