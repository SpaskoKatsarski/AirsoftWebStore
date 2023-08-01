namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Gunsmith;

    public interface IGunsmithService
    {
        Task BecomeGunsmithAsync(string userId, BecomeGunsmithFormModel model);

        Task<bool> IsGunsmithAsync(string userId);
    }
}
