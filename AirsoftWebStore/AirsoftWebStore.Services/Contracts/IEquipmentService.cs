namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Models.Equipment;
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public interface IEquipmentService
    {
        Task<Equipment> GetEquipmentByIdAsync(string id);

        Task<AllEquipmentFilteredAndPagedServiceModel> AllAsync(AllEquipmentQueryModel queryModel);

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
