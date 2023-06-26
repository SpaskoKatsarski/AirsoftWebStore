namespace AirsoftWebStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        public Cart? Cart { get; set; }
    }
}
