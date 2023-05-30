namespace OnlineStore.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsHidden { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public List<Characteristic> Characteristics { get; set; } = new();
        public List<PriceChange> PriceChanges { get; set; } = new();
        public List<Picture> Pictures { get; set; } = new();
        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Delivery> Deliveries { get; set; } = new();
        public List<Basket> Baskets { get; set; } = new();
    }
}