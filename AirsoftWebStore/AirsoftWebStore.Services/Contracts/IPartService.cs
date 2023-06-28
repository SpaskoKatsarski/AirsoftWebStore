namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Part;

    public interface IPartService
    {
        Task<IEnumerable<PartAllViewModel>> AllAsync();

        Task<PartDetailViewModel> GetDetailsAsync(string id);
    }
}
