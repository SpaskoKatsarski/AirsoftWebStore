namespace AirsoftWebStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.User;
    using AirsoftWebStore.Web.ViewModels.Gunsmith;
    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessages;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IGunsmithService gunsmithService;

        public UserController(IUserService userService, IGunsmithService gunsmithService)
        {
            this.userService = userService;
            this.gunsmithService = gunsmithService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();

            return View(users);
        }

        public async Task<IActionResult> Gunsmiths()
        {
            IEnumerable<GunsmithViewModel> gunsmiths = await this.gunsmithService.AllAsync();

            return View(gunsmiths);
        }

        public async Task<IActionResult> RemoveGunsmith(string userId, string userEmail)
        {
            try
            {
                await this.gunsmithService.RemoveGunsmithAsync(userId);
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home", new { Area =  AdminAreaName});
            }

            TempData[SuccessMessage] = $"The Gunsmith privileges have been successfully removed from user with email '{userEmail}'!";
            return RedirectToAction("Gunsmiths", "User", new { Area = AdminAreaName });
        }
    }
}
