namespace OnlineStore.Domain
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductCount { get; set; }
    }

}
