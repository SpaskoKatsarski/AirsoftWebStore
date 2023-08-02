namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Consumative;
    using AirsoftWebStore.Services.Models.Consumative;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using static Common.NotificationMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class ConsumativeController : Controller
    {
        private readonly IConsumativeService consumativeService;
        private readonly IGunsmithService gunsmithService;

        public ConsumativeController(IConsumativeService consumativeService, IGunsmithService gunsmithService)
        {
            this.consumativeService = consumativeService;
            this.gunsmithService = gunsmithService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllConsumativesQueryModel queryModel)
        {
            AllConsumativesFilteredAndSortedServiceModel serviceModel = await this.consumativeService.AllAsync(queryModel);

            queryModel.Consumatives = serviceModel.Consumatives;
            queryModel.TotalConsumatives = serviceModel.TotalConsumativesCount;

            return View(queryModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.consumativeService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Consumative");
            }

            ConsumativeDetailsViewModel model = await this.consumativeService.GetForDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            ConsumativeFormViewModel model = new ConsumativeFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConsumativeFormViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool alreadyExists = await this.consumativeService.ExistsByNameAsync(model.Name);
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Item with this name already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string id = await this.consumativeService.AddAsync(model);

                TempData[SuccessMessage] = "Item was successuly added!";
                return RedirectToAction("Details", "Consumative", new { id });
            }
            catch (Exception)
            {
                TempData[SuccessMessage] = "Unexpected error occured while trying to add your item! Try again";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool exists = await this.consumativeService.ExistsByIdAsync(id);
            if (!exists)
            {
                TempData[ErrorMessage] = "Item with the provided ID does not exist!";
                return RedirectToAction("All", "Consumative");
            }

            ConsumativeFormViewModel model = await this.consumativeService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConsumativeFormViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool nameExists = await this.consumativeService.ExistsByNameAsync(model.Name);
            string currentName = await this.consumativeService.GetCurrentNameAsync(model.Id!);
            if (nameExists && model.Name != currentName)
            {
                ModelState.AddModelError(nameof(model.Name), "Equipment with this name already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.consumativeService.EditAsync(model);

                TempData[SuccessMessage] = "Item successuly modified!";
                return RedirectToAction("Details", "Consumative", new { id = model.Id });
            }
            catch (Exception)
            {
                TempData[SuccessMessage] = "Unexpected error occured while trying to edit your item! Try again";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool exists = await this.consumativeService.ExistsByIdAsync(id);
            if (!exists)
            {
                TempData[ErrorMessage] = "Item with the provided ID does not exist!";
                return RedirectToAction("All", "Consumative");
            }

            ConsumativeDeleteViewModel model = await this.consumativeService.GetForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ConsumativeDeleteViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool exists = await this.consumativeService.ExistsByIdAsync(id);

            if (!exists)
            {
                TempData["ErrorMessage"] = "Item with the provided Id does not exist!";

                return RedirectToAction("All", "Consumative");
            }

            try
            {
                await this.consumativeService.DeleteAsync(id);

                TempData[WarningMessage] = "Item was deleted.";
                return RedirectToAction("All", "Consumative");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again or contact administrator!";

            return RedirectToAction("Index", "Home");
        }

        private async Task HandleUserRights()
        {
            bool isGunsmith = await this.gunsmithService.IsGunsmithAsync(User.GetId()!);
            bool isAdmin = User.IsInRole(AdminRoleName);

            if (!isGunsmith && !isAdmin)
            {
                throw new InvalidOperationException("You must become a Gunsmith in order to do this action!");
            }
        }
    } 
}
