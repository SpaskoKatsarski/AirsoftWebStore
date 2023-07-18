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

            await this.walletService.DepositToUserAccountAsync(userId, model.Money);

            TempData[SuccessMessage] = $"You have successfuly made a ${model.Money:f2} deposit!";

            return RedirectToAction("Index", "Home");
        }
    }
}
