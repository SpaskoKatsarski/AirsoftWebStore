namespace AirsoftWebStore.Services
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly AirsoftStoreDbContext context;

        public CartService(AirsoftStoreDbContext context)
        {
            this.context = context;
        }

        public async Task AddItemAsync(CartItem item, string userId)
        {
            bool hasUserCart = await this.context.Carts
                .AnyAsync(c => c.BuyerId.ToString() == userId);
            if (!hasUserCart)
            {
                // Adding cart to user
                ApplicationUser user = await this.context.Users
                    .FirstAsync(u => u.Id.ToString() == userId);

                user.Cart = new Cart();
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
                cart.CartItems.Add(item);
            }
            else
            {
                // Update this to users selected quantity
                item.Quantity++;
            }

            await this.context.SaveChangesAsync();
        }
    }
}
