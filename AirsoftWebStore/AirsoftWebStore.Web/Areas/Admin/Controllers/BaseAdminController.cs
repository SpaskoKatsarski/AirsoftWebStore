﻿namespace AirsoftWebStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.GeneralApplicationConstants;

    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
