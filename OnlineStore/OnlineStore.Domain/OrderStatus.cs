namespace OnlineStore.Domain
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Order> Orders { get; set; } = new();
    }
}
