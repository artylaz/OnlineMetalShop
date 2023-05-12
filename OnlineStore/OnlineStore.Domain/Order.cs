namespace OnlineStore.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid UserId { get; set; }
        public Guid StoreId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
