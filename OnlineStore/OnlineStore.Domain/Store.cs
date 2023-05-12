namespace OnlineStore.Domain
{
    public class Store
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsHidden { get; set; }
    }
}
