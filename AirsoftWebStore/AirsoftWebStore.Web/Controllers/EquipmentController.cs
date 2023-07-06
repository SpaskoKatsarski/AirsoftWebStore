namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.ViewModels.Equipment;
    using AirsoftWebStore.Services.Contracts;

    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<EquipmentAllViewModel> models = await this.equipmentService.AllAsync();

            return View(models);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.equipmentService.ExistsByIdAsync(id);
            if (!exists)
            {
                // Custom error page will be better maybe?
                return RedirectToAction("All", "Equipmenmt");
            }

            EquipmentDetailsViewModel model = await this.equipmentService.GetForDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // TODO: If the user is not a weapon creator, he should be redirected to become one
            // If the user is not a creator, add to tempData a message telling the user he should become a creator
            // toastr will handle this
            // Redirect to Become Creator page
            EquipmentFormViewModel formModel = new EquipmentFormViewModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EquipmentFormViewModel model)
        {
            bool alreadyExists = await this.equipmentService.ExistsByNameAsync(model.Name);
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Equipment with this name already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string id = await this.equipmentService.AddAsync(model);

                return RedirectToAction("Details", "Equipment", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your equipment! Please try again or contact administrator!");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }
    }
}
