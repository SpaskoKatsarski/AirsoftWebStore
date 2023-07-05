namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Equipment;

    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentAllViewModel>> AllAsync();
    }
}
