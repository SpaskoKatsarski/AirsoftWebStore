namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartItem
    {
        public CartItem()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        public Cart Cart { get; set; } = null!;

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductType { get; set; } = null!;

        public Gun? Gun { get; set; }

        public Part? Part { get; set; }

        public Equipment? Equipment { get; set; }

        public Consumative? Consumative { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}