namespace OnlineStore.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public Guid RoleId { get; set; }
        public bool IsAccess { get; set; }

        public Role Role { get; set; } = null!;
        public List<Basket> Baskets { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
