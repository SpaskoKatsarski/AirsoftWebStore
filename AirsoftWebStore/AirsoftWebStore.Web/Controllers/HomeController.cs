namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}