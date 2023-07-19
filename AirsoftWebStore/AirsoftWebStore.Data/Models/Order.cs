namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.ProductsIds = new Dictionary<string, string>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;

        [NotMapped]
        public Dictionary<string, string> ProductsIds { get; set; } = null!;
    }
}
