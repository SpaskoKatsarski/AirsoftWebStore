namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using AirsoftWebStore.Web.ViewModels.Home;

    public interface IGunService
    {
        Task<Gun> GetGunByIdAsync(string id);

        Task AddItemToUsersCart(string itemId, string userId);

        Task<IEnumerable<IndexViewModel>> GetTopThreeWithMostCountsAsync();

        Task<IEnumerable<GunAllViewModel>> AllAsync();

        Task<GunDetailViewModel> GetDetailsAsync(string Id);

        Task<string> AddAsync(GunFormViewModel model);

        Task<string> EditAsync(GunFormViewModel model);

        Task DeleteAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<GunFormViewModel> GetGunForEditByIdAsync(string id);

        Task<GunDeleteViewModel> GetGunForDeleteByIdAsync(string id);
    }
}
