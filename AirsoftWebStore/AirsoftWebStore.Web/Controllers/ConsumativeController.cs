namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Consumative;
    using AirsoftWebStore.Web.ViewModels.Equipment;

    [Authorize]
    public class ConsumativeController : Controller
    {
        private readonly IConsumativeService consumativeService;

        public ConsumativeController(IConsumativeService consumativeService)
        {
            this.consumativeService = consumativeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<ConsumativeAllViewModel> consumatives = await this.consumativeService.AllAsync();

            return View(consumatives);
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
            ConsumativeFormViewModel model = new ConsumativeFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConsumativeFormViewModel model)
        {
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

                return RedirectToAction("Details", "Consumative", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your consumative! Please try again or contact administrator!");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool exists = await this.consumativeService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Consumative");
            }

            ConsumativeFormViewModel model = await this.consumativeService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConsumativeFormViewModel model)
        {
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

                return RedirectToAction("Details", "Consumative", new { id = model.Id });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool exists = await this.consumativeService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Consumative");
            }

            ConsumativeDeleteViewModel model = await this.consumativeService.GetForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, EquipmentDeleteViewModel model)
        {
            bool exists = await this.consumativeService.ExistsByIdAsync(id);

            if (!exists)
            {
                TempData["ErrorMessage"] = "Consumative with the provided Id does not exist!";

                return RedirectToAction("All", "Consumative");
            }

            // Check if user is weapon creator...
            // Thats how:
            //if (!isUserWeaponCreator)
            //{
            //    TempData[ErrorMessage] = "You must become a weapon creator in order to delete items!";

            //    return this.RedirectToAction("Become", "WeaponCreator");
            //}

            try
            {
                await this.consumativeService.DeleteAsync(id);

                //TempData[WarningMessage] = "Item successfuly deleted!";
                return RedirectToAction("All", "Consumative");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            //TempData["ErrorMessage"] = "Unexpected error occurred! Please try again or contact administrator!";

            return View("Index", "Home");
        }
    } 
}
