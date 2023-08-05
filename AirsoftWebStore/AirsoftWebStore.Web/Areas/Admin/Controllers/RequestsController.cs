namespace AirsoftWebStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Admin;
    using static AirsoftWebStore.Common.NotificationMessages;

    public class RequestsController : BaseAdminController
    {
        private readonly IAdminService adminService;
        private readonly IGunsmithService gunsmithService;

        public RequestsController(IAdminService adminService, IGunsmithService gunsmithService)
        {
            this.adminService = adminService;
            this.gunsmithService = gunsmithService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllRequestsViewModel> models = await this.adminService.GetAllReqeustsAsync();

            return View(models);
        }

        public async Task<IActionResult> Approve(string userId, string userEmail)
        {
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
