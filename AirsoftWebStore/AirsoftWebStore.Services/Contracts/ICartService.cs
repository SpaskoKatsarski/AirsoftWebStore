namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;

    public interface ICartService
    {
        Task AddItemAsync(CartItem item, string userId);
    }
}
