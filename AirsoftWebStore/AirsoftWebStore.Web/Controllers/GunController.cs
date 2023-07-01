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
            // Check if category exists when submitted bc the user can change the id in the html
            // ModelState.AddModelError(typeof(model.CategoryId), "Selected category does not exist!")
            // Load the categories again and redirect to add with the same model
            return Ok();
        }
    }
}
