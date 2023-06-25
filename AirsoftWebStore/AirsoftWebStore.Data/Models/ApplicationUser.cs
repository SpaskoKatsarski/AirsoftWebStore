namespace AirsoftWebStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Purchases = new HashSet<Order>();
        }

        public Order CurrentOrder { get; set; } = null!;

        public ICollection<Order> Purchases = null!;
    }
}
