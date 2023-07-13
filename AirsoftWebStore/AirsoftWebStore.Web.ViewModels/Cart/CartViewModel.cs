namespace AirsoftWebStore.Web.ViewModels.Cart
{
    using AirsoftWebStore.Web.ViewModels.CartItem;

    public class CartViewModel
    {
        public decimal TotalPrice { get; set; }

        public IEnumerable<CartItemViewModel> CartItems { get; set; } = null!;
    }
}
