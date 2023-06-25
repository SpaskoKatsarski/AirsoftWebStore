namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AirsoftWebStore.Common.EntityValidationConstants.Consumative;

    public class Consumative
    {
        public Consumative()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
