namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Web.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
