namespace AirsoftWebStore.Services.Contracts
{
    public interface IGunsmithService
    {
        Task BecomeGunsmithAsync(string userId);

        Task RemoveRequestAsync(string userId);

        Task<bool> IsGunsmithAsync(string userId);

        Task AddUserRequestAsync(string userId);

        Task<bool> HasUserSentRequestAsync(string userId);
    }
}
