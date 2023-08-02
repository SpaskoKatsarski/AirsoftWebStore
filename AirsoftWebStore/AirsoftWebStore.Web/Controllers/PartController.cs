namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Part;
    using AirsoftWebStore.Services.Models.Part;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using static Common.NotificationMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class PartController : Controller
    {
        private readonly IPartService partService;
        private readonly ICategoryService categoryService;
        private readonly IGunsmithService gunsmithService;

        public PartController(
            IPartService partService,
            ICategoryService categoryService, 
            IGunsmithService gunsmithService)
        {
            this.partService = partService;
            this.categoryService = categoryService;
            this.gunsmithService = gunsmithService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            PartFormViewModel model = new PartFormViewModel()
            {
                Categories = await this.categoryService.AllAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PartFormViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool alreadyExists = await this.partService.ExistsByNameAsync(model.Name);
            if (alreadyExists)
            {
                ModelState.AddModelError(nameof(model.Name), "Part with this name already exists!");
            }

            bool isCategoryValid = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!isCategoryValid)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllAsync();
                return View(model);
            }

            try
            {
                string id = await this.partService.AddAsync(model);

                TempData[SuccessMessage] = "Part was added successfully!";
                return RedirectToAction("Details", "Part", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your part. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool exists = await this.partService.ExistsByIdAsync(id);
            if (!exists)
            {
                TempData[ErrorMessage] = "Part with the provided ID does not exist!";
                return RedirectToAction("All", "Part");
            }

            try
            {
                PartFormViewModel model = await this.partService.GetPartForEditAsync(id);
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartFormViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllAsync();
                return View(model);
            }

            try
            {
                string id = await this.partService.EditAsync(model);

                TempData[SuccessMessage] = "Part was successfuly modified!";
                return RedirectToAction("Details", "Part", new { id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to edit your part. Try again.");
                model.Categories = await this.categoryService.AllAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool exists = await this.partService.ExistsByIdAsync(id);
            if (!exists)
            {
                TempData[ErrorMessage] = "Part with the provided ID does not exist!";
                return RedirectToAction("All", "Part");
            }
            try
            {
                PartDeleteViewModel model = await this.partService.GetPartForDeleteAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, PartDeleteViewModel model)
        {
            try
            {
                await this.HandleUserRights();
            }
            catch (InvalidOperationException e)
            {
                TempData[ErrorMessage] = e.Message;
                return RedirectToAction("Index", "Home");
            }

            bool partExists = await this.partService.ExistsByIdAsync(id);

            if (!partExists)
            {
                TempData["ErrorMessage"] = "Part with the provided Id does not exist!";

                return RedirectToAction("All", "Part");
            }

            try
            {
                await this.partService.DeleteAsync(id);

                TempData[WarningMessage] = "Item was deleted.";
                return RedirectToAction("All", "Part");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllPartsQueryModel queryModel)
        {
            AllPartsFilteredAndPagedServiceModel serviceModel = await this.partService.AllAsync(queryModel);

            queryModel.Parts = serviceModel.Parts;
            queryModel.TotalParts = serviceModel.TotalPartsCount;
            queryModel.Categories = await this.categoryService.AllNamesAsync();

            return View(queryModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.partService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Part");
            }

            PartDetailViewModel partModel = await this.partService
                .GetDetailsAsync(id);

            return View(partModel);
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again or contact administrator!";
            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> HandleUserRights()
        {
            bool isGunsmith = await this.gunsmithService.IsGunsmithAsync(User.GetId()!);
            bool isAdmin = User.IsInRole(AdminRoleName);

            if (!isGunsmith && !isAdmin)
            {
                TempData[ErrorMessage] = "You must become a Gunsmith in order to do this action!";
                return RedirectToAction("Index", "Home");
            }

            return Ok();
        }
    }
}
