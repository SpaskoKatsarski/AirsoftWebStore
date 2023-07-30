namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using static AirsoftWebStore.Common.NotificationMessages;
    using AirsoftWebStore.Services.Models.Gun;

    [Authorize]
    public class GunController : Controller
    {
        private readonly IGunService gunService;
        private readonly ICategoryService categoryService;

        public GunController(IGunService gunService, ICategoryService categoryService)
        {
            this.gunService = gunService;
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllGunsQueryModel queryModel)
        {
            AllGunsFilteredAndPagedServiceModel serviceModel = await this.gunService.AllAsync(queryModel);

            queryModel.Guns = serviceModel.Guns;
            queryModel.TotalGuns = serviceModel.TotalGunsCount;
            queryModel.Categories = await this.categoryService.AllNamesAsync();

            return View(queryModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.gunService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Gun");
            }

            GunDetailViewModel gunModel = await this.gunService
                .GetDetailsAsync(id);

            return View(gunModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            // Check whether the user is WeaponCreator. If not he cannot edit. Also add error message to the TempData
            if (!await this.gunService.ExistsByIdAsync(id))
            {
                TempData[ErrorMessage] = "Replica with the provided ID does not exist!";

                return RedirectToAction("All", "Gun");
            }

            try
            {
                GunFormViewModel model = await this.gunService.GetGunForEditByIdAsync(id);
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, GunFormViewModel model)
        {
            bool exists = await this.gunService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("Error", "Home");
            }

            bool nameExists = await this.gunService.ExistsByNameAsync(model.Name);
            string currentName = await this.gunService.GetCurrentNameAsync(model.Id!);
            if (nameExists && model.Name != currentName)
            {
                ModelState.AddModelError(nameof(model.Name), "Replica with this name already exists!");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllAsync();
                return View(model);
            }

            try
            {
                await this.gunService.EditAsync(model);

                TempData[SuccessMessage] = "Replica successfuly modified!";
                return RedirectToAction("Details", "Gun", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to edit your replica. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO: If the user is not a weapon creator, he should be redirected to become one
            // If the user is not a creator, add to tempData a message telling the user he should become a creator
            // toastr will handle this
            // Redirect to Become Creator page
            GunFormViewModel formModel = new GunFormViewModel()
            {
                Categories = await this.categoryService.AllAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GunFormViewModel model)
        {
            if (await this.gunService.ExistsByNameAsync(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Replica with this name already exists!");
            }

            if (!await this.categoryService.ExistsByIdAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }

            try
            {
                string id = await this.gunService.AddAsync(model);

                TempData[SuccessMessage] = "Replica was added successfully!";

                return RedirectToAction("Details", "Gun", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your replica. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            // TODO: Check if user is weapon craetor, only he can remove
            if (!await this.gunService.ExistsByIdAsync(id))
            {
                TempData[ErrorMessage] = "Replica with the provided ID does not exist!";

                return RedirectToAction("All", "Gun");
            }

            try
            {
                GunDeleteViewModel model = await this.gunService.GetGunForDeleteByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, GunDeleteViewModel model)
        {
            bool gunExists = await this.gunService.ExistsByIdAsync(id);

            if (!gunExists)
            {
                TempData["ErrorMessage"] = "Replica with the provided ID does not exist!";

                return RedirectToAction("All", "Gun");
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
                await this.gunService.DeleteAsync(id);

                TempData[WarningMessage] = "Item was deleted.";
                return RedirectToAction("All", "Gun");
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
    }
}
