namespace AirsoftWebStore.Services.Tests.Cart
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Data.Models;
    using AirsoftWebStore.Web.ViewModels.Cart;
    using static CartDatabaseSeeder;

    public class CartServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private ICartService cartService;

        public CartItem EquipmentItem;
        public CartItem ConsumativeItem;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForCart(dbContext);

            cartService = new CartService(dbContext);

            EquipmentItem = new CartItem()
            {
                Equipment = CartDatabaseSeeder.Equipment,
                Quantity = 3
            };

            ConsumativeItem = new CartItem()
            {
                Consumative = CartDatabaseSeeder.Consumative,
                Quantity = 2
            };
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForCart(dbContext);
        }

        [Test]
        public async Task RemoveItemFromCartShouldRemoveItem()
        {
            const int expectedItemsCount = 0;

            CartItem cartItem = new CartItem()
            {
                Equipment = CartDatabaseSeeder.Equipment,
                Quantity = 1
            };

            await this.cartService.AddItemAsync(cartItem, User.Id.ToString());
            await this.cartService.RemoveItemFromCart(cartItem.Id.ToString());
            int acutalItemsCount = (await this.cartService.GetCartForUserAsync(User.Id.ToString())).CartItems.Count;

            Assert.AreEqual(expectedItemsCount, acutalItemsCount);
        }

        [Test]
        public async Task AddItemShouldAddTheItemIfDoesntExistInCart()
        {
            const int expectedItemsCount = 1;

            await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());

            Assert.AreEqual(User.Cart.CartItems.Count, expectedItemsCount);
        }

        [Test]
        public async Task AddItemShouldIncreaseCountIfExistsInCart()
        {
            const int expectedAmountOfProduct = 3;

            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment }, User.Id.ToString());
            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment }, User.Id.ToString());
            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment }, User.Id.ToString());

            Assert.AreEqual(expectedAmountOfProduct, EquipmentItem.Quantity);
        }

        [Test]
        public void AddItemThrowsWhenConsumativeDoesntExistAndNoCountsLeft()
        {
            CartDatabaseSeeder.Consumative.Quantity = 0;
            dbContext.SaveChanges();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(ConsumativeItem, User.Id.ToString());
            }, $"There are no '{ConsumativeItem.Consumative.Name}' in stock!");
        }

        [Test]
        public async Task AddItemThrowsWhenConsumativeExistsAndNoMoreInStorage()
        {
            CartDatabaseSeeder.Consumative.Quantity = 1;
            dbContext.SaveChanges();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(ConsumativeItem, User.Id.ToString());
                await this.cartService.AddItemAsync(ConsumativeItem, User.Id.ToString());
            }, $"You cannot add more '{ConsumativeItem.Consumative.Name}' to the cart than there is in stock!");
        }

        [Test]
        public void AddItemThrowsWhenEquipmentDoesntExistAndNoCountsLeft()
        {
            CartDatabaseSeeder.Equipment.Quantity = 0;
            dbContext.SaveChanges();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
            }, $"There are no '{EquipmentItem.Equipment.Name}' in stock!");
        }

        [Test]
        public async Task AddItemThrowsWhenEquipmentExistsAndNoMoreInStorage()
        {
            CartDatabaseSeeder.Equipment.Quantity = 1;
            dbContext.SaveChanges();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
                await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
            }, $"You cannot add more '{EquipmentItem.Equipment.Name}' to the cart than there is in stock!");
        }

        [Test]
        public void AddItemThrowsWhenGunDoesntExistAndNoCountsLeft()
        {
            CartItem gunItem = new CartItem()
            {
                Quantity = 1,
                Gun = new Gun() { Name = "Test", Quantity = 0 }
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(gunItem, User.Id.ToString());
            }, $"There are no '{gunItem.Gun.Name}' in stock!");
        }

        [Test]
        public async Task AddItemThrowsWhenGunExistsAndNoMoreInStorage()
        {
            Gun gun = new Gun()
            {
                Name = "Test",
                Quantity = 1
            };

            CartItem gunItem = new CartItem()
            {
                Gun = new Gun() { Name = "Test" }
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
                await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
            }, $"You cannot add more '{EquipmentItem.Equipment.Name}' to the cart than there is in stock!");
        }

        [Test]
        public async Task CreateCardForUserShouldCreateCart()
        {
            await this.cartService.CreateCartForUserAsync(User.Id.ToString());

            Assert.IsNotNull(User.Cart);
        }

        [Test]
        public async Task CreateCardForUserShouldThrowWhenUserAlreadyHasOne()
        {
            await this.cartService.CreateCartForUserAsync(User.Id.ToString());

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await this.cartService.CreateCartForUserAsync(User.Id.ToString());
            }, "User already has a cart!");
        }

        [Test]
        public void CreateCardForUserShouldThrowWhenUserIdIsInvalid()
        {
            const string invalidUserId = "X";

            Assert.ThrowsAsync<Exception>(async () =>
            {
                await this.cartService.CreateCartForUserAsync(invalidUserId);
            }, "User does not exist!");
        }

        [Test]
        public async Task GetCartForUserAsyncShouldReturnCartForUser()
        {
            Cart cart = await this.cartService.GetCartForUserAsync(User.Id.ToString());

            Assert.IsNotNull(cart);
        }

        //[Test]
        //public async Task GetCartForVisualizationShouldReturnCorrectViewModel()
        //{
        //    decimal expectedTotalPrice = EquipmentItem.Equipment.Price + ConsumativeItem.Consumative.Price;

        //    await this.cartService.AddItemAsync(EquipmentItem, User.Id.ToString());
        //    await this.cartService.AddItemAsync(new CartItem() { Consumative = CartDatabaseSeeder.Consumative, Quantity = 1 }, User.Id.ToString());

        //    CartViewModel model = await this.cartService.GetCartForVisualizationAsync(User.Id.ToString());
        //    decimal totalPrice = model.TotalPrice;

        //    Assert.IsNotNull(model);
        //    Assert.AreEqual(expectedTotalPrice, totalPrice);
        //}

        [Test]
        public async Task CalculateTotalPriceForCartByIdShouldReturnCorrectTotalPrice()
        {
            decimal totalPrice = EquipmentItem.Equipment.Price * 2;

            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment, Quantity = 1 }, User.Id.ToString());
            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment, Quantity = 1 }, User.Id.ToString());

            Cart cart = await this.cartService.GetCartForUserAsync(User.Id.ToString());
            decimal actualTotalPrice = this.cartService.CalculateTotalPriceForCartById(cart);

            Assert.AreEqual(totalPrice, actualTotalPrice);
        }

        [Test]
        public async Task EmptyCartForUserByIdShouldRemoveAllProducts()
        {
            const int expectedProductCount = 0;

            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment, Quantity = 1 }, User.Id.ToString());
            await this.cartService.AddItemAsync(new CartItem() { Equipment = CartDatabaseSeeder.Equipment, Quantity = 1 }, User.Id.ToString());

            await this.cartService.EmptyCartForUserById(User.Id.ToString());
            Cart cart = await this.cartService.GetCartForUserAsync(User.Id.ToString());

            Assert.AreEqual(expectedProductCount, cart.CartItems.Count);
        }
    }
}
