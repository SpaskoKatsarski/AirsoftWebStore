namespace AirsoftWebStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
            // TODO: Move the admin controller in the area to avoid route problems
        }
    }
}
