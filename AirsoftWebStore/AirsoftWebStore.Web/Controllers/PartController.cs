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

        public PartController(IPartService partService)
        {
            this.partService = partService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PartAllViewModel> parts = await this.partService
                .AllAsync();

            return View(parts);
        }

        public async Task<IActionResult> Details(string id)
        {
            PartDetailViewModel partModel = await this.partService
                .GetDetailsAsync(id);

            return View(partModel);
        }
    }
}
