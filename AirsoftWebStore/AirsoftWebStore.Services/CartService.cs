namespace AirsoftWebStore.Services
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Cart;
    using AirsoftWebStore.Web.ViewModels.CartItem;

    public class CartService : ICartService
    {
        private readonly AirsoftStoreDbContext context;

        public CartService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task AddItemAsync(CartItem item, string userId)
        {
            bool hasUserCart = await this.HasUserCart(userId);
            if (!hasUserCart)
            {
                // Adding cart to user
                await this.CreateCartForUserAsync(userId);
            }

            Cart cart = await this.context.Carts
                .FirstAsync(c => c.BuyerId.ToString() == userId);

            bool itemExistsInCurrentCart;
            if (item.Gun != null)
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.GunId.ToString() == item.GunId.ToString());
            }
            else if (item.Part != null)
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.PartId.ToString() == item.PartId.ToString());
            }
            else if (item.Equipment != null)
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.EquipmentId.ToString() == item.EquipmentId.ToString());
            }
            else if (item.Consumative != null)
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.ConsumativeId.ToString() == item.ConsumativeId.ToString());
            }
            else
            {
                itemExistsInCurrentCart = false;
            }

            if (!itemExistsInCurrentCart)
            {
                // Create a new cart item if no cart item exists.
                // The quantity is set in the controller
                item.CartId = cart.Id;
                await this.context.CartItems.AddAsync(item);
            }
            else
            {
                // Update this to users selected quantity
                item.Quantity++;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<Cart> CreateCartForUserAsync(string userId)
        {
            bool hasUserCart = await this.HasUserCart(userId);
            if (!hasUserCart)
            {
                ApplicationUser user = await this.context.Users
                    .FirstAsync(u => u.Id.ToString() == userId);

                if (user == null)
                {
                    throw new Exception("User does not exist!");
                }

                Cart cart = new Cart()
                {
                    BuyerId = Guid.Parse(userId)
                };

                await this.context.Carts.AddAsync(cart);

                this.context.Entry(user).Reload();
                this.context.Entry(cart).Reload();

                await this.context.SaveChangesAsync();

                return cart;
            }

            throw new ArgumentException("User already has a cart!");
        }

        public async Task<Cart> GetCartForUserAsync(string userId)
        {
            bool hasUserCart = await this.HasUserCart(userId);
            if (!hasUserCart)
            {
                await this.CreateCartForUserAsync(userId);
            }

            Cart cart = await this.context.Carts
                .Include(c => c.CartItems)
                .FirstAsync(c => c.BuyerId.ToString() == userId);

            return cart;
        }

        public async Task<CartViewModel> GetCartForVisualizationAsync(string userId)
        {
            Cart cart = await this.GetCartForUserAsync(userId);

            CartViewModel model = new CartViewModel()
            {
                TotalPrice = cart.TotalPrice,
                CartItems = cart.CartItems
                .Select(ci => new CartItemViewModel()
                {
                    ProductName = this.GetProductName(ci),
                    Quantity = ci.Quantity,
                    PricePerItem = GetPricePerItem(ci),
                    TotalPrice = GetPricePerItem(ci) * ci.Quantity
                })
            };

            return model;
        }

        private async Task<bool> HasUserCart(string userId) => await this.context.Carts
                .AnyAsync(c => c.BuyerId.ToString() == userId);

        private string GetProductName(CartItem item)
        {
            if (item.Gun != null)
            {
                return item.Gun.Name;
            }
            else if (item.Part != null)
            {
                return item.Part.Name;
            }
            else if (item.Equipment != null)
            {
                return item.Equipment.Name;
            }
            else if (item.Consumative != null)
            {
                return item.Consumative.Name;
            }

            return "Unknown Product";
        }

        private decimal GetPricePerItem(CartItem item)
        {
            if (item.Gun != null)
            {
                return item.Gun.Price;
            }
            else if (item.Part != null)
            {
                return item.Part.Price;
            }
            else if (item.Equipment != null)
            {
                return item.Equipment.Price;
            }
            else if (item.Consumative != null)
            {
                return item.Consumative.Price;
            }

            return 0;
        }
    }
}
