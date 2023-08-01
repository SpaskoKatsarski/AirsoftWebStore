namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Admin;

    public interface IAdminService
    {
        Task<IEnumerable<AllRequestsViewModel>> GetAllReqeustsAsync();
    }
}
