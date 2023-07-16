namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using AirsoftWebStore.Web.ViewModels.Cart;

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IWalletService walletService;
        private readonly IGunService gunService;
        private readonly IPartService partService;
        private readonly IEquipmentService equipmentService;
        private readonly IConsumativeService consumativeService;

        public CartController(
            ICartService cartService,
            IWalletService walletService,
            IGunService gunService,
            IPartService partService,
            IEquipmentService equipmentService,
            IConsumativeService consumativeService)
        {
            this.cartService = cartService;
            this.walletService = walletService;
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

            // Set Quantity
            CartItem? item;
            if (productType == "gun")
            {
                Gun gun = await this.gunService.GetGunByIdAsync(itemId);

                item = new CartItem()
                {
                    GunId = gun.Id,
                    Gun = gun,
                    Quantity = quantity
                };
            }
            else if (productType == "part")
            {
                Part part = await this.partService.GetPartByIdAsync(itemId);

                item = new CartItem()
                {
                    PartId = part.Id,
                    Part = part
                };
            }
            else if (productType == "equipment")
            {
                Equipment equipment = await this.equipmentService.GetEquipmentByIdAsync(itemId);

                item = new CartItem()
                {
                    EquipmentId = equipment.Id,
                    Equipment = equipment
                };
            }
            else if (productType == "consumative")
            {
                Consumative consumative = await this.consumativeService.GetConsumativeByIdAsync(itemId);

                item = new CartItem()
                {
                    ConsumativeId = consumative.Id,
                    Consumative = consumative
                };
            }
            else
            {
                // Error page
                return NotFound();
            }
            await this.cartService.AddItemAsync(item, userId!);

            return RedirectToAction("ViewCart", "Cart");
        }

        public async Task<IActionResult> ViewCart()
        {
            string? userId = ClaimsPrincipalExtensions.GetId(this.User);
            if (userId == null)
            {
                // User should be logged in in order to see his cart
            }

            CartViewModel model = await this.cartService.GetCartForVisualizationAsync(userId!);

            model.TotalPrice = model.CartItems
                .Sum(i => i.PricePerItem * i.Quantity);

            return View(model);
        }

        public async Task<IActionResult> PurchaseAll()
        {
            // 1. Check if user has enough money to buy all products in his cart.
            // 1.1 If he hasn't then display an error message and suggest him to deposit money. With button or sth...
            // 2. Substract his money from the total money of his products and display a thank you message.

            string userId = this.User.GetId()!;

            Cart cart = await this.cartService.GetCartForUserAsync(userId);

            decimal userMoney = await this.walletService.GetMoneyForUserByIdAsync(userId);
            decimal cartTotalMoney = this.cartService.CalculateTotalPriceForCartById(cart);

            if (userMoney < cartTotalMoney)
            {
                return RedirectToAction("ViewCart", "Cart");
            }

            await this.cartService.ReduceMoneyFromUserByIdAsync();
        }
    }
}
