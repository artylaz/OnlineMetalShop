namespace OnlineStore.Domain
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
