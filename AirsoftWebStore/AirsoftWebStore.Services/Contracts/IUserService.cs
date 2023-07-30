namespace AirsoftWebStore.Services.Contracts
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);
    }
}
