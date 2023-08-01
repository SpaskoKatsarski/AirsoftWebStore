namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using static Common.NotificationMessages;

    public class GunsmithController : Controller
    {
        private readonly IGunsmithService gunsmithService;

        public GunsmithController(IGunsmithService gunsmithService)
        {
            this.gunsmithService = gunsmithService;
        }

        public async Task<IActionResult> RequestToBecome(string userId)
        {
            // TODO: Dont let admins and non-authenticated users access this action!
            // See why the button doesnt hide after clicking for request.
            // In the admin controller check why when approving someone he doesnt disappear from the list of request.
            try
            {
                await this.gunsmithService.AddUserRequestAsync(userId);

                TempData[SuccessMessage] = "Request was sent successfully!";
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
