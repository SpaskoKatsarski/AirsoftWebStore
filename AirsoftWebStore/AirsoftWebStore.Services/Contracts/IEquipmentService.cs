namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentAllViewModel>> AllAsync();

        Task<string> AddAsync(EquipmentFormViewModel model);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<EquipmentDetailsViewModel> GetForDetailsAsync(string id);
    }
}
