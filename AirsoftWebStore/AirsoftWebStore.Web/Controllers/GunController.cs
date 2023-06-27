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

        public GunController(IGunService gunService)
        {
            this.gunService = gunService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<GunAllViewModel> guns = await this.gunService
                .AllAsync();

            return View(guns);
        }

        public async Task<IActionResult> Details(string id)
        {
            GunDetailViewModel gunModel = await this.gunService
                .GetDetailsAsync(id);

            return View(gunModel);
        }
    }
}
