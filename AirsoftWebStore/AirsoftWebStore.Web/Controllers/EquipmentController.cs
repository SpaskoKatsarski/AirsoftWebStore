namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.ViewModels.Equipment;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Services.Models.Equipment;
    using static Common.NotificationMessages;

    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
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
            // TODO: If the user is not a weapon creator, he should be redirected to become one
            // If the user is not a creator, add to tempData a message telling the user he should become a creator
            // toastr will handle this
            // Redirect to Become Creator page
            EquipmentFormViewModel formModel = new EquipmentFormViewModel();

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EquipmentFormViewModel model)
        {
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
            bool exists = await this.equipmentService.ExistsByIdAsync(id);

            if (!exists)
            {
                TempData[ErrorMessage] = "Equipment with the provided ID does not exist!";

                return RedirectToAction("All", "Equipment");
            }

            // Check if user is weapon creator...
            // Thats how:
            //if (!isUserWeaponCreator)
            //{
            //    TempData[ErrorMessage] = "You must become a weapon creator in order to delete items!";

            //    return this.RedirectToAction("Become", "WeaponCreator");
            //}

            try
            {
                await this.equipmentService.DeleteAsync(id);

                TempData[WarningMessage] = "Item successfuly deleted!";
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
    }
}
