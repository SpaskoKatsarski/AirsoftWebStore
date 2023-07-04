namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Gun;

    public interface IGunService
    {
        Task<IEnumerable<GunAllViewModel>> AllAsync();

        Task<GunDetailViewModel> GetDetailsAsync(string Id);

        Task<string> AddAsync(GunFormViewModel model);

        Task<string> EditAsync(string id, GunFormViewModel model);

        Task DeleteAsync(string id);

        Task<bool> ExistsByIdAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<GunFormViewModel> GetGunForEditByIdAsync(string id);

        Task<GunDeleteViewModel> GetGunForDeleteByIdAsync(string id);
    }
}
