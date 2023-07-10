namespace AirsoftWebStore.Web.ViewModels.Consumative
{
    using System.ComponentModel.DataAnnotations;

    using static AirsoftWebStore.Common.EntityValidationConstants.Consumative;

    public class ConsumativeFormViewModel
    {
        public string? Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Range(QuantityMin, QuantityMax)]
        public int Quantity { get; set; }

    }
}
