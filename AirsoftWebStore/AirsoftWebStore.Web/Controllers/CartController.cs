namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using AirsoftWebStore.Web.ViewModels.Cart;

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
        public async Task<IActionResult> AddToCart(string itemId, string productType)
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
                    Gun = gun
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

            // Redirect to the cart view
            return RedirectToAction("ViewCart", "Cart");
        }

        // View cart
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
    }
}
