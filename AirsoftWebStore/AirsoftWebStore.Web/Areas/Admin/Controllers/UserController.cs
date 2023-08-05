﻿namespace AirsoftWebStore.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.User;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();

            return View(users);
        }
    }
}
