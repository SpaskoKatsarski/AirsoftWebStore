namespace AirsoftWebStore.Web.ViewModels.Gunsmith
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Gunsmith;

    public class BecomeGunsmithFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
