namespace OnlineStore.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsHidden { get; set; }
    }
}
