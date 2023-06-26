namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static AirsoftWebStore.Common.EntityValidationConstants.Gun;

    public class Gun
    {
        public Gun()
        {
            this.Id = Guid.NewGuid();
            this.Attachments = new HashSet<Part>();
            this.CartItems = new HashSet<CartItem>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public ICollection<Part> Attachments { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
