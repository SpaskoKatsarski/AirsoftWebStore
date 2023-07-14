namespace AirsoftWebStore.Services.Contracts
{
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Cart;

    public interface ICartService
    {
        Task AddItemAsync(CartItem item, string userId);

        Task<Cart> CreateCartForUserAsync(string userId);

        Task<Cart> GetCartForUserAsync(string userId);

        Task<CartViewModel> GetCartForVisualizationAsync(string userId);

        Task<decimal> CalculateTotalPriceForCartById(string id);
    }
}
