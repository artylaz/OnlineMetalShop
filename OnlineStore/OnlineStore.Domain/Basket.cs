namespace OnlineStore.Domain
{
    public class Basket
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int AmountProduct { get; set; }
        public Product Product { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
