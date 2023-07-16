namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        public decimal Money { get; set; }

        [ForeignKey(nameof(Cart))]
        public Guid? CartId { get; set; }

        public Cart? Cart { get; set; }
    }
}
