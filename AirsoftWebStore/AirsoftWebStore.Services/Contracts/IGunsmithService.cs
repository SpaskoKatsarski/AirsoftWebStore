namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.Gunsmith;

    public interface IGunsmithService
    {
        Task<IEnumerable<GunsmithViewModel>> AllAsync();

        Task BecomeGunsmithAsync(string userId);

        Task RemoveGunsmithAsync(string userId);

        Task RemoveRequestAsync(string userId);

        Task<bool> IsGunsmithAsync(string userId);

        Task AddUserRequestAsync(string userId);

        Task<bool> HasUserSentRequestAsync(string userId);
    }
}
