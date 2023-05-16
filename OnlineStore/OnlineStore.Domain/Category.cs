namespace OnlineStore.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsHidden { get; set; }

        public Guid? CategoryId { get; set; }
        public Category? CategoryNavigation { get; set; }
        public List<Category> InverseCategoryNavigation { get; set; } = new();
        public List<Product> Products { get; set; } = new();

    }
}
