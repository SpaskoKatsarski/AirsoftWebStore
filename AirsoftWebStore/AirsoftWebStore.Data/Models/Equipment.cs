namespace AirsoftWebStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AirsoftWebStore.Common.EntityValidationConstants.Equipment;

    public class Equipment
    {
        public Equipment()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
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
