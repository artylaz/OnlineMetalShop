namespace OnlineStore.Domain
{
    public class Delivery
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid StoreId { get; set; }
        public Store Store { get; set; } = null!;

        public DateTime DeliveryDate { get; set; }
        public int ProductCount { get; set; }
        
    }

}
