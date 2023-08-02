namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.ViewModels.Equipment;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Services.Models.Equipment;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using static Common.NotificationMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService equipmentService;
        private readonly IGunsmithService gunsmithService;

        public EquipmentController(IEquipmentService equipmentService, IGunsmithService gunsmithService)
        {
            this.equipmentService = equipmentService;
            this.gunsmithService = gunsmithService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllEquipmentQueryModel queryModel)
        {
            AllEquipmentFilteredAndPagedServiceModel serviceModel = await this.equipmentService.AllAsync(queryModel);

            queryModel.AllEquipment = serviceModel.AllEquipment;
            queryModel.TotalItems = serviceModel.TotalEquipmentCount;
            
            return View(queryModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.equipmentService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Equipmenmt");
            }

            EquipmentDetailsViewModel model = await this.equipmentService.GetForDetailsAsync(id);

            return View(model);
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

            EquipmentFormViewModel formModel = new EquipmentFormViewModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EquipmentFormViewModel model)
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

                TempData[SuccessMessage] = "Equipment was added successfully!";
                return RedirectToAction("Details", "Equipment", new { id });
            }
            catch (Exception)
            {
                TempData[SuccessMessage] = "Unexpected error occured while trying to add your equipment! Try again";
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

            bool exists = await this.equipmentService.ExistsByIdAsync(id);
            if (!exists)
            {
                return RedirectToAction("All", "Equipment");
            }

            EquipmentFormViewModel model = await this.equipmentService.GetForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentFormViewModel model)
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

            bool nameExists = await this.equipmentService.ExistsByNameAsync(model.Name);
            string currentName = await this.equipmentService.GetCurrentNameAsync(model.Id!);
            if (nameExists && model.Name != currentName)
            {
                ModelState.AddModelError(nameof(model.Name), "Equipment with this name already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string id = await this.equipmentService.EditAsync(model);

                TempData[SuccessMessage] = "Equipment was modified successfuly!";
                return RedirectToAction("Details", "Equipment", new { id });
            }
            catch (Exception)
            {
                TempData[SuccessMessage] = "Unexpected error occured while trying to edit your equipment! Try again";
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

            bool exists = await this.equipmentService.ExistsByIdAsync(id);
            if (!exists)
            {
                TempData[ErrorMessage] = "Equipment with the provided ID does not exist!";

                return RedirectToAction("All", "Equipment");
            }

            EquipmentDeleteViewModel model = await this.equipmentService.GetForDeleteAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, EquipmentDeleteViewModel model)
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

            bool exists = await this.equipmentService.ExistsByIdAsync(id);

            if (!exists)
            {
                TempData[ErrorMessage] = "Equipment with the provided ID does not exist!";

                return RedirectToAction("All", "Equipment");
            }

            try
            {
                await this.equipmentService.DeleteAsync(id);

                TempData[WarningMessage] = "Item was deleted.";
                return RedirectToAction("All", "Equipment");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again or contact administrator!";

            return RedirectToAction("Index", "Home");
        }

        private async Task HandleUserRights()
        {
            bool isGunsmith = await this.gunsmithService.IsGunsmithAsync(User.GetId()!);
            bool isAdmin = User.IsInRole(AdminRoleName);

            if (!isGunsmith && !isAdmin)
            {
                throw new InvalidOperationException("You must become a Gunsmith in order to do this action!");
            }
        }
    }
}
