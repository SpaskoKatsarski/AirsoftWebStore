namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Web.ViewModels.Equipment;
    using AirsoftWebStore.Services.Contracts;

    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EquipmentAllViewModel> models = await this.equipmentService.AllAsync();

            return View(models);
        }
    }
}
