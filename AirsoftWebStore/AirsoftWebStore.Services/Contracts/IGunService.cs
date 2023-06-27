namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Gun;

    public interface IGunService
    {
        Task<IEnumerable<GunAllViewModel>> AllAsync();

        Task<GunDetailViewModel> GetDetailsAsync(string Id);
    }
}
