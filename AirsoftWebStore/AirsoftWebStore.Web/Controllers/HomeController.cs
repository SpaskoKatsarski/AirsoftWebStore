namespace AirsoftWebStore.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.ViewModels;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IGunService gunService;

        public HomeController(IGunService gunService)
        {
            this.gunService = gunService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> model = await this.gunService.GetTopThreeWithMostCountsAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}