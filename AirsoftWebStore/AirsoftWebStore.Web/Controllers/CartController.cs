namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        private readonly IGunService gunService;
        private readonly IPartService partService;
        private readonly IEquipmentService equipmentService;
        private readonly IConsumativeService consumativeService;

        public CartController(
            ICartService cartService,
            IGunService gunService,
            IPartService partService,
            IEquipmentService equipmentService,
            IConsumativeService consumativeService)
        {
            this.cartService = cartService;
            this.gunService = gunService;
            this.partService = partService;
            this.equipmentService = equipmentService;
            this.consumativeService = consumativeService;
        }

        // Add item to cart
        public async Task<IActionResult> AddToCart(string itemId, int quantity, string productType)
        {
            string? userId = ClaimsPrincipalExtensions.GetId(this.User);

            if (userId == null)
            {
                // Error page or notify the user that he needs to log in
            }

            CartItem? item = null;
            if (productType == "gun")
            {
                Gun gun = await this.gunService.GetGunByIdAsync(itemId);

                item = new CartItem()
                {
                    Gun = gun
                };
            }
            else if (productType == "part")
            {
                Part part = await this.partService.GetPartByIdAsync(itemId);
            }
            else
            {
                return NotFound();
            }
            await this.cartService.AddItemAsync(item, userId!);

            // Redirect to the cart view
            return RedirectToAction("ViewCart");
        }

        // View cart
        //public async Task<IActionResult> ViewCart()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        // Handle user not found
        //        return NotFound();
        //    }

        //    var cart = await GetOrCreateCartForUser(user);

        //    return View(cart);
        //}

        //// Helper method to get or create the cart for a user
        //private async Task<Cart> GetOrCreateCartForUser(ApplicationUser user)
        //{
        //    var cart = await _context.Carts
        //        .Include(c => c.CartItems)
        //        .FirstOrDefaultAsync(c => c.BuyerId == user.Id);

        //    if (cart == null)
        //    {
        //        cart = new Cart
        //        {
        //            Id = Guid.NewGuid(),
        //            BuyerId = user.Id,
        //            CartItems = new List<CartItem>()
        //        };

        //        _context.Carts.Add(cart);
        //        await _context.SaveChangesAsync();
        //    }

        //    return cart;
        //}
    }
}
