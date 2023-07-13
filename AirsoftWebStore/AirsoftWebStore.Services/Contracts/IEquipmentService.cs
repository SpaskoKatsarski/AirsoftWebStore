namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public interface IEquipmentService
    {
        Task<Equipment> GetEquipmentByIdAsync(string id);

        Task<IEnumerable<EquipmentAllViewModel>> AllAsync();

        Task<string> AddAsync(EquipmentFormViewModel model);

        Task<string> EditAsync(EquipmentFormViewModel model);

        Task DeleteAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<EquipmentDetailsViewModel> GetForDetailsAsync(string id);

        Task<EquipmentFormViewModel> GetForEditAsync(string id);

        Task<EquipmentDeleteViewModel> GetForDeleteAsync(string id);

        Task<string> GetCurrentNameAsync(string id);
    }
}
