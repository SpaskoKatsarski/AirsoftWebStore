namespace AirsoftWebStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.Infrastructure.Extensions;
    using AirsoftWebStore.Web.ViewModels.Cart;
    using static AirsoftWebStore.Common.NotificationMessages;
    using static AirsoftWebStore.Common.GeneralApplicationConstants;

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

        public async Task<IActionResult> AddToCart(string itemId, int quantity, string productType)
        {
            if (User.IsInRole(AdminRoleName))
            {
                TempData[ErrorMessage] = "Admins cannot have a cart!";
                return RedirectToAction("Index", "Home");
            }

            string userId = User.GetId()!;

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
                    Part = part,
                    Quantity = quantity
                };
            }
            else if (productType == "equipment")
            {
                Equipment equipment = await this.equipmentService.GetEquipmentByIdAsync(itemId);

                item = new CartItem()
                {
                    EquipmentId = equipment.Id,
                    Equipment = equipment,
                    Quantity = quantity
                };
            }
            else if (productType == "consumative")
            {
                Consumative consumative = await this.consumativeService.GetConsumativeByIdAsync(itemId);

                item = new CartItem()
                {
                    ConsumativeId = consumative.Id,
                    Consumative = consumative,
                    Quantity = quantity
                };
            }
            else
            {
                // Error page
                return NotFound();
            }

            try
            {
                await this.cartService.AddItemAsync(item, userId!);

                return RedirectToAction("ViewCart", "Cart");
            }
            catch (InvalidOperationException ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        public async Task<IActionResult> ViewCart()
        {
            if (User.IsInRole(AdminRoleName))
            {
                TempData[ErrorMessage] = "Admins cannot have a cart!";
                return RedirectToAction("Index", "Home");
            }

            string? userId = ClaimsPrincipalExtensions.GetId(this.User);

            CartViewModel model = await this.cartService.GetCartForVisualizationAsync(userId!);

            model.TotalPrice = model.CartItems
                .Sum(i => i.PricePerItem * i.Quantity);

            return View(model);
        }

        public async Task<IActionResult> RemoveItem(string itemId)
        {
            try
            {
                await this.cartService.RemoveItemFromCart(itemId);

                return RedirectToAction("ViewCart", "Cart");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        public async Task<IActionResult> PurchaseAll()
        {
            string userId = this.User.GetId()!;

            Cart cart = await this.cartService.GetCartForUserAsync(userId);

            decimal userMoney = await this.walletService.GetMoneyForUserByIdAsync(userId);
            decimal cartTotalMoney = this.cartService.CalculateTotalPriceForCartById(cart);

            if (userMoney < cartTotalMoney)
            {
                TempData[ErrorMessage] = "You don't have enough money in the account to buy the products in your cart!";
                return RedirectToAction("Deposit", "Wallet");
            }

            try
            {
                await this.walletService.ReduceMoneyFromUserByIdAsync(userId, cartTotalMoney);
                await this.cartService.EmptyCartForUserById(userId);

                TempData[SuccessMessage] = "You have successfuly made your purchase!";
                return RedirectToAction("ThankYou", "Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred!";
                return RedirectToAction("Index", "Home");
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occurred! Please try again or contact administrator!";
            return RedirectToAction("Index", "Home");
        }
    }
}
