namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Consumative;

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
            if (exists)
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
    } 
}
