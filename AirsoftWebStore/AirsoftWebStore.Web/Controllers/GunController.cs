namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gun;

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
        public async Task<IActionResult> All()
        {
            IEnumerable<GunAllViewModel> guns = await this.gunService
                .AllAsync();

            return View(guns);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // TODO: add validation or redirect to custom error page
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
                // If id does not exist you should add an error message to the TempData, toastr will handle it, and redirect to all replicas

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
            // TODO: make a validation for id if is valid
            //if (!await this.gunService.ExistsByIdAsync(id))
            //{
            //    ModelState.AddModelError(, "Invalid id");
            //}
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
                await this.gunService.EditAsync(id, model);

                return RedirectToAction("Details", "Gun", new { id });
            }
            catch (Exception)
            {
                return this.GeneralError();
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

                // with toastr js
                // this.TempData[SuccessMessage] = "Replica was added successfully!";

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

        // TODO: Implement the logic inside:
        [HttpPost]
        public async Task<IActionResult> Delete(string id, GunDeleteViewModel model)
        {
            bool gunExists = await this.gunService.ExistsByIdAsync(id);

            if (!gunExists)
            {
                TempData["ErrorMessage"] = "Replica with the provided Id does not exist!";

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

                //TempData[WarningMessage] = "Item successfuly deleted!";
                return RedirectToAction("All", "Gun");
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
