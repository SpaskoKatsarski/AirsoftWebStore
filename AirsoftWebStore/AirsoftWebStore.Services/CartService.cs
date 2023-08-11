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

        public async Task RemoveItemFromCart(string itemId)
        {
            CartItem? item = await this.context.CartItems.FindAsync(Guid.Parse(itemId));

            this.context.CartItems.Remove(item!);

            await this.context.SaveChangesAsync();
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
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Gun)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Part)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Equipment)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Consumative)
                .FirstAsync(c => c.BuyerId.ToString() == userId);

            string? itemType = this.GetTypeOfItem(item);
            bool itemExistsInCurrentCart;
            
            if (itemType == "gun")
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.GunId.ToString() == item.GunId.ToString());
            }
            else if (itemType == "part")
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.PartId.ToString() == item.PartId.ToString());
            }
            else if (itemType == "equipment")
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.EquipmentId.ToString() == item.EquipmentId.ToString());
            }
            else if (itemType == "consumative")
            {
                itemExistsInCurrentCart = cart.CartItems.Any(ci => ci.ConsumativeId.ToString() == item.ConsumativeId.ToString());
            }
            else
            {
                itemExistsInCurrentCart = false;
            }

            if (!itemExistsInCurrentCart)
            {
                if (itemType == "gun")
                {
                    if (item.Gun!.Quantity == 0)
                    {
                        throw new InvalidOperationException($"There are no '{item.Gun.Name}' in stock!");
                    }
                }
                else if (itemType == "part")
                {
                    if (item.Part!.Quantity == 0)
                    {
                        throw new InvalidOperationException($"There are no '{item.Part.Name}' in stock!");
                    }
                }
                else if (itemType == "equipment")
                {
                    if (item.Equipment!.Quantity == 0)
                    {
                        throw new InvalidOperationException($"There are no '{item.Equipment.Name}' in stock!");
                    }
                }
                else if (itemType == "consumative")
                {
                    if (item.Consumative!.Quantity == 0)
                    {
                        throw new InvalidOperationException($"There are no '{item.Consumative.Name}' in stock!");
                    }
                }
                
                item.CartId = cart.Id;
                await this.context.CartItems.AddAsync(item);
            }
            else
            {
                CartItem currentItem;

                if (itemType == "gun")
                {
                    currentItem = cart.CartItems.First(ci => ci.Gun?.Name == item.Gun!.Name);

                    int totalCounts = currentItem.Quantity + 1;

                    if (totalCounts > currentItem.Gun!.Quantity)
                    {
                        throw new InvalidOperationException($"You cannot add more '{currentItem.Gun.Name}' to the cart than there is in stock!");
                    }
                }
                else if (itemType == "part")
                {
                    currentItem = cart.CartItems.First(ci => ci.Part?.Name == item.Part!.Name);

                    int totalCounts = currentItem.Quantity + 1;

                    if (totalCounts > currentItem.Part!.Quantity)
                    {
                        throw new InvalidOperationException($"You cannot add more '{currentItem.Part.Name}' to the cart than there is in stock!");
                    }
                }
                else if (itemType == "equipment")
                {
                    currentItem = cart.CartItems.First(ci => ci.Equipment?.Name == item.Equipment!.Name);

                    int totalCounts = currentItem.Quantity + 1;

                    if (totalCounts > currentItem.Equipment!.Quantity)
                    {
                        throw new InvalidOperationException($"You cannot add more '{currentItem.Equipment.Name}' to the cart than there is in stock!");
                    }
                }
                else
                {
                    currentItem = cart.CartItems.First(ci => ci.Consumative?.Name == item.Consumative!.Name);

                    int totalCounts = currentItem.Quantity + 1;

                    if (totalCounts > currentItem.Consumative!.Quantity)
                    {
                        throw new InvalidOperationException($"You cannot add more '{currentItem.Consumative.Name}' to the cart than there is in stock!");
                    }
                }

                currentItem.Quantity++;
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
                    BuyerId = Guid.Parse(userId),
                    TotalPrice = 0
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
                .ThenInclude(c => c.Gun)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Part)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Equipment)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Consumative)
                .FirstAsync(c => c.BuyerId.ToString() == userId);

            await this.RemoveUnavailibleItems(cart);

            return cart;
        }

        private async Task RemoveUnavailibleItems(Cart cart)
        {
            foreach (CartItem item in cart.CartItems)
            {
                string? itemType = this.GetTypeOfItem(item);
                bool exists = false;

                if (itemType == "gun")
                {
                    exists = await this.CheckIfItemStllExists(item.GunId.ToString()!, itemType);
                }
                else if (itemType == "part")
                {
                    exists = await this.CheckIfItemStllExists(item.PartId.ToString()!, itemType);
                }
                else if (itemType == "equipment")
                {
                    exists = await this.CheckIfItemStllExists(item.EquipmentId.ToString(), itemType);
                }
                else if (itemType == "consumative")
                {
                    exists = await this.CheckIfItemStllExists(item.ConsumativeId.ToString(), itemType);
                }

                if (!exists)
                {
                    context.CartItems.Remove(item);
                    await this.context.SaveChangesAsync();
                }
            }
        }

        public async Task<CartViewModel> GetCartForVisualizationAsync(string userId)
        {
            Cart cart = await this.GetCartForUserAsync(userId);

            decimal totalPrice = this.CalculateTotalPriceForCartById(cart);

            CartViewModel model = new CartViewModel()
            {
                TotalPrice = totalPrice,
                CartItems = cart.CartItems
                .Select(ci => new CartItemViewModel()
                {
                    ProductId = this.GetIdForItem(ci)!,
                    CartItemId = ci.Id.ToString(),
                    ProductName = this.GetProductName(ci),
                    Quantity = ci.Quantity,
                    PricePerItem = GetPricePerItem(ci),
                    TotalPrice = GetPricePerItem(ci) * ci.Quantity,
                    ProductType = this.GetTypeOfItem(ci)!
                })
            };

            return model;
        }

        public decimal CalculateTotalPriceForCartById(Cart cart)
        {
            decimal totalPrice = 0;

            foreach (CartItem item in cart.CartItems)
            {
                string? itemType = this.GetTypeOfItem(item);

                if (itemType == "gun")
                {
                    totalPrice += item.Gun!.Price * item.Quantity;
                }
                else if (itemType == "part")
                {
                    totalPrice += item.Part!.Price * item.Quantity;
                }
                else if (itemType == "equipment")
                {
                    totalPrice += item.Equipment!.Price * item.Quantity;
                }
                else if (itemType == "consumative")
                {
                    totalPrice += item.Consumative!.Price * item.Quantity;
                }
            }

            return totalPrice;
        }

        public async Task EmptyCartForUserById(string userId)
        {
            Cart cart = await this.GetCartForUserAsync(userId);

            foreach (CartItem item in cart.CartItems)
            {
                string itemType = this.GetTypeOfItem(item)!;

                if (itemType == "gun")
                {
                    item.Gun!.Quantity -= item.Quantity;
                }
                else if (itemType == "part")
                {
                    item.Part!.Quantity -= item.Quantity;
                }
                else if (itemType == "equipment")
                {
                    item.Equipment!.Quantity -= item.Quantity;
                }
                else if (itemType == "consumative")
                {
                    item.Consumative!.Quantity -= item.Quantity;
                }
            }

            this.context.CartItems.RemoveRange(cart.CartItems);

            await this.context.SaveChangesAsync();
        }

        private async Task<bool> CheckIfItemStllExists(string id, string productType)
        {
            if (productType == "gun")
            {
                return await this.context.Guns
                    .Where(g => g.IsActive)
                    .AnyAsync(g => g.Id.ToString() == id);
            }

            if (productType == "part")
            {
                return await this.context.Parts
                    .Where(p => p.IsActive)
                    .AnyAsync(p => p.Id.ToString() == id);
            }

            if (productType == "equipment")
            {
                return await this.context.Equipments
                    .Where(e => e.IsActive)
                    .AnyAsync(e => e.Id.ToString() == id);
            }

            if (productType == "consumative")
            {
                return await this.context.Consumatives
                    .Where(c => c.IsActive)
                    .AnyAsync(c => c.Id.ToString() == id);
            }

            return false;
        }

        private string? GetTypeOfItem(CartItem item)
        {
            if (item.Gun != null)
            {
                return "gun";
            }
            else if (item.Part != null)
            {
                return "part";
            }
            else if (item.Equipment != null)
            {
                return "equipment";
            }
            else if (item.Consumative != null)
            {
                return "consumative";
            }

            return null;
        }

        private string? GetIdForItem(CartItem item)
        {
            string itemType = this.GetTypeOfItem(item)!;

            if (itemType == "gun")
            {
                return item.GunId.ToString();
            }
            else if (itemType == "part")
            {
                return item.PartId.ToString();
            }
            else if (itemType == "equipment")
            {
                return item.EquipmentId.ToString();
            }
            else if (itemType == "consumative")
            {
                return item.ConsumativeId.ToString();
            }

            return null;
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
