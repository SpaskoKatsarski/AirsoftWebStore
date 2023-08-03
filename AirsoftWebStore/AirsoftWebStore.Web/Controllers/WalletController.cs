namespace AirsoftWebStore.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Wallet;
    using static AirsoftWebStore.Common.NotificationMessages;

    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService walletService;

        public WalletController(IWalletService walletService)
        {
            this.walletService = walletService;
        }

        [HttpGet]
        public async Task<IActionResult> Deposit()
        {
            string userId = this.User.GetId()!;
            decimal currentMoney = await this.walletService.GetMoneyForUserByIdAsync(userId);
            string email = this.User.FindFirst(ClaimTypes.Name)!.Value;

            UserDepositViewModel model = new UserDepositViewModel()
            {
                UserId = userId,
                CurrentMoney = currentMoney,
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(UserDepositViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = this.User.GetId()!;

            try
            {
                await this.walletService.DepositToUserAccountAsync(userId, model.Money);

                TempData[SuccessMessage] = $"You have successfuly made a ${model.Money:f2} deposit!";
                return RedirectToAction("ViewCart", "Cart");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to make a deposit! Try again later or contact administrator!";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
