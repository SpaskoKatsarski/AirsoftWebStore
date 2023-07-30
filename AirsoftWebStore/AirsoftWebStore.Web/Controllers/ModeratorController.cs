namespace AirsoftWebStore.Web.Controllers
{
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationMessages;

    public class ModeratorController : Controller
    {
        //[HttpGet]
        //public async Task<IActionResult> Become()
        //{
        //    string? userId = User.GetId();

        //    bool isModerator = await moderatorService.ModExistsByUserIdAsync(userId!);

        //    if (isModerator)
        //    {
        //        TempData[ErrorMessage] = "You are already a moderator!";

        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Become(BecomeModViewModel model)
        //{
        //    string? userId = User.GetId();
        //    bool isAgent = await moderatorService.ModExistsByUserIdAsync(userId);
        //    if (isAgent)
        //    {
        //        TempData[ErrorMessage] = "You are already a moderator!";

        //        return RedirectToAction("Index", "Home");
        //    }

        //    bool isPhoneNumberTaken = await moderatorService.ModExistsByPhoneNumberAsync(model.PhoneNumber);

        //    if (isPhoneNumberTaken)
        //    {
        //        ModelState.AddModelError(nameof(model.PhoneNumber), "Moderator with the provided phone number already exists!");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    try
        //    {
        //        await moderatorService.CreateModAsync(userId, model);
        //        TempData[SuccessMessage] = "You are now a moderator!";
        //    }
        //    catch (Exception)
        //    {
        //        TempData[ErrorMessage] =
        //            "Unexpected error occurred while registering you as a moderator! Please try again later or contact administrator.";
        //    }

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
