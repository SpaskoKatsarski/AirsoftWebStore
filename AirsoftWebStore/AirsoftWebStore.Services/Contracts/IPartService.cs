namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Part;

    public interface IPartService
    {
        Task<Part> GetPartByIdAsync(string id);

        Task<IEnumerable<PartAllViewModel>> AllAsync();

        Task<string> AddAsync(PartFormViewModel model);

        Task<string> EditAsync(PartFormViewModel model);

        Task DeleteAsync(string id);

        Task<PartFormViewModel> GetPartForEditAsync(string id);

        Task<PartDeleteViewModel> GetPartForDeleteAsync(string id);

        Task<PartDetailViewModel> GetDetailsAsync(string id);

        Task<bool> ExistsByNameAsync(string name);

        Task<bool> ExistsByIdAsync(string id);
    }
}
