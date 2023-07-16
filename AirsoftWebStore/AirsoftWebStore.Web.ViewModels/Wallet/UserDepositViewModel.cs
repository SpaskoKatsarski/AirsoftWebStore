namespace AirsoftWebStore.Web.ViewModels.Wallet
{
    using System.ComponentModel.DataAnnotations;

    public class UserDepositViewModel
    {
        public string? UserId { get; set; }

        public decimal? CurrentMoney { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "The amount for deposit must be between {1} and {2}.")]
        public decimal Money { get; set; }

        public string? Email { get; set; }
    }
}
