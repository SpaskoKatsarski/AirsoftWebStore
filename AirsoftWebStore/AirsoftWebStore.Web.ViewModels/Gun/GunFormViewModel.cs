namespace AirsoftWebStore.Web.ViewModels.Gun
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftWebStore.Web.ViewModels.Category;
    using static AirsoftWebStore.Common.EntityValidationConstants.Gun;

    public class GunFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ManufacturerMaxLength, MinimumLength = ManufacturerMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(YearMin, YearMax)]
        public int Year { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Range(QuantityMin, QuantityMax)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryFormViewModel>? Categories { get; set; }
    }
}
