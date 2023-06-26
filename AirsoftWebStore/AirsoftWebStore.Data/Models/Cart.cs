namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid();
            this.CartItems = new HashSet<CartItem>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Buyer))]
        [Required]
        public Guid BuyerId { get; set; }

        [Required]
        public ApplicationUser Buyer { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
