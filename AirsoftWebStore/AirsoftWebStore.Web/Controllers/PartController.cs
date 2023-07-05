namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Part;

    [Authorize]
    public class PartController : Controller
    {
        private readonly IPartService partService;
        private readonly ICategoryService categoryService;

        public PartController(IPartService partService, ICategoryService categoryService)
        {
            this.partService = partService;
            this.categoryService = categoryService;
        }

        // Only weapon creator should be able to add parts
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            PartFormViewModel model = new PartFormViewModel()
            {
                Categories = await this.categoryService.AllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PartFormViewModel model)
        {
            bool alreadyExists = await this.partService.ExistsByNameAsync(model.Name);
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Part with this name already exists!");
            }

            bool isCategoryValid = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!isCategoryValid)
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
                string id = await this.partService.AddAsync(model);

                // with toastr js
                // this.TempData[SuccessMessage] = "Part was added successfully!";

                return RedirectToAction("Details", "Part", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your replica. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool exists = await this.partService.ExistsByIdAsync(id);
            if (!exists)
            {
                // If id does not exist you should add an error message to the TempData, toastr will handle it, and redirect to all replicas

                return RedirectToAction("All", "Part");
            }

            try
            {
                PartFormViewModel model = await this.partService.GetPartForEditAsync(id);
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PartFormViewModel model)
        {
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
                await this.partService.EditAsync(id, model);

                return RedirectToAction("Details", "Part", new { id });
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool exists = await this.partService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Part");
            }
            try
            {
                PartDeleteViewModel model = await this.partService.GetPartForDeleteAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        // TODO: Really IMPORTANT! Only weapon creators can modify or delete items (and see the corresponding buttons)!
        [HttpPost]
        public async Task<IActionResult> Delete(string id, PartDeleteViewModel model)
        {
            bool partExists = await this.partService.ExistsByIdAsync(id);

            if (!partExists)
            {
                TempData["ErrorMessage"] = "Part with the provided Id does not exist!";

                return RedirectToAction("All", "Part");
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
                await this.partService.DeleteAsync(id);

                //TempData[WarningMessage] = "Item successfuly deleted!";
                return RedirectToAction("All", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<PartAllViewModel> parts = await this.partService
                .AllAsync();

            return View(parts);
        }

        // TODO: Check for invalid id
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            PartDetailViewModel partModel = await this.partService
                .GetDetailsAsync(id);

            return View(partModel);
        }

        private IActionResult GeneralError()
        {
            //TempData[ErrorMessage] = "Unexpected error occurred! Please try again or contact administrator!";

            return View("Index", "Home");
        }
    }
}
