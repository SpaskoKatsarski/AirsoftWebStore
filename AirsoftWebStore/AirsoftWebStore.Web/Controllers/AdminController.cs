namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Admin;
    using static Common.NotificationMessages;

    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IGunsmithService gunsmithService;

        public AdminController(IAdminService adminService, IGunsmithService gunsmithService)
        {
            this.adminService = adminService;
            this.gunsmithService = gunsmithService;
        }

        public async Task<IActionResult> Requests()
        {
            IEnumerable<AllRequestsViewModel> models = await this.adminService.GetAllReqeustsAsync();

            return View(models);
        }

        public async Task<IActionResult> Approve(string userId)
        {
            try
            {
                await this.gunsmithService.BecomeGunsmithAsync(userId);

                string userEmail = User.Identity!.Name!;
                TempData[SuccessMessage] = $"User with email '{userEmail}' is now a Gunsmith!";
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;
            }

            return RedirectToAction("Requests", "Admin");
        }

        public async Task<IActionResult> Decline(string userId)
        {
            try
            {
                await this.gunsmithService.RemoveRequestAsync(userId);

                string userEmail = User.Identity!.Name!;
                TempData[WarningMessage] = $"User with email '{userEmail}' was rejected!";
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;
            }

            return RedirectToAction("Requests", "Admin");
        }
    }
}
