namespace AirsoftWebStore.Web.ViewModels.CartItem
{
    public class CartItemViewModel
    {
        public string Id { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal PricePerItem { get; set; }

        public decimal TotalPrice { get; set; }

        public string ProductType { get; set; } = null!;
    }
}
