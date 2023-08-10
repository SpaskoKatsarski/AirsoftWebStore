namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using static Common.NotificationMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class GunsmithController : Controller
    {
        private readonly IGunsmithService gunsmithService;

        public GunsmithController(IGunsmithService gunsmithService)
        {
            this.gunsmithService = gunsmithService;
        }

        public async Task<IActionResult> RequestToBecome(string userId)
        {
            if (userId == null)
            {
                userId = User.GetId()!;
            }

            bool isGunsmith = await this.gunsmithService.IsGunsmithAsync(userId);
            bool isAdmin = User.IsInRole(AdminRoleName);
            bool hasSent = await this.gunsmithService.HasUserSentRequestAsync(userId);

            try
            {
                if (isGunsmith)
                {
                    throw new Exception("User is already a Gunsmith!");
                }

                if (isAdmin)
                {
                    throw new Exception("Admins cannot become a Gunsmith!");
                }

                if (hasSent)
                {
                    throw new Exception("You have already sent a request for Gunsmith!");
                }

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
