namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Admin;
    using static Common.NotificationMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
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
            if (!User.IsInRole(AdminRoleName))
            {
                TempData[ErrorMessage] = "Only administrators have access to requests!";
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<AllRequestsViewModel> models = await this.adminService.GetAllReqeustsAsync();

            return View(models);
        }

        public async Task<IActionResult> Approve(string userId, string userEmail)
        {
            if (!User.IsInRole(AdminRoleName))
            {
                TempData[ErrorMessage] = "Only administrators can approve requests!";
                return RedirectToAction("Index", "Home");
            }

            if (await this.gunsmithService.IsGunsmithAsync(userId))
            {
                TempData[ErrorMessage] = "User is already a gunsmith!";

                return RedirectToAction("Requests", "Admin");
            }

            try
            {
                await this.gunsmithService.BecomeGunsmithAsync(userId);

                TempData[SuccessMessage] = $"User with email '{userEmail}' is now a Gunsmith!";
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;
            }

            return RedirectToAction("Requests", "Admin");
        }

        public async Task<IActionResult> Decline(string userId, string userEmail)
        {
            if (!User.IsInRole(AdminRoleName))
            {
                TempData[ErrorMessage] = "Only administrators can decline requests!";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await this.gunsmithService.RemoveRequestAsync(userId);

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
