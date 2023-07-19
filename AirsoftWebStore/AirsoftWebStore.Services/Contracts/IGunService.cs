namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Models.Gun;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using AirsoftWebStore.Web.ViewModels.Home;

    public interface IGunService
    {
        Task<Gun> GetGunByIdAsync(string id);

        Task<IEnumerable<IndexViewModel>> GetTopThreeWithMostCountsAsync();

        Task<AllGunsFilteredAndPagedServiceModel> AllAsync(AllGunsQueryModel queryModel);

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
