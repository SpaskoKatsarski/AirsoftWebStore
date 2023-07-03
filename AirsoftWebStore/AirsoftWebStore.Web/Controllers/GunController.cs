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
                // TODO: Chech why gun is not being found by the service:
                GunFormViewModel model = await this.gunService.GetGunForEditByIdAsync(id);
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
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
                // this.TempData[SuccessMessage] = "House was added successfully!";

                return RedirectToAction("Details", "Gun", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your replica. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        private IActionResult GeneralError()
        {
            TempData["ErrorMessage"] = "Unexpected error occurred! Please try again or contact administrator!";

            return View("Index", "Home");
        }
    }
}
