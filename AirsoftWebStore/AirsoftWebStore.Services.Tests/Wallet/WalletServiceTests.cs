namespace AirsoftWebStore.Services.Tests.Wallet
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using static WalletDatabaseSeeder;

    public class WalletServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private IWalletService walletService;

        [OneTimeSetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForWallet(dbContext);

            walletService = new WalletService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForWallet(dbContext);
        }

        [Test]
        public async Task DepositToUserAccountShouldAddCorrectAmount()
        {
            const decimal expectedAmount = 50.50m;

            await this.walletService.DepositToUserAccountAsync(User.Id.ToString(), 50.50m);

            Assert.AreEqual(User.Money, expectedAmount);
        }

        [Test]
        public async Task ReduceMoneyFromUserByIdShouldRemoveCorrectAmount()
        {
            const decimal expectedAmount = 5;

            await this.walletService.DepositToUserAccountAsync(User.Id.ToString(), 55.50m);
            await this.walletService.ReduceMoneyFromUserByIdAsync(User.Id.ToString(), 50.50m);

            Assert.AreEqual(User.Money, expectedAmount);
        }

        [Test]
        public async Task GetMoneyForUserByIdShouldReturnCorrectAmount()
        {
            const decimal expectedAmount = 50;

            await this.walletService.DepositToUserAccountAsync(User.Id.ToString(), 50);
            decimal userMoney = await this.walletService.GetMoneyForUserByIdAsync(User.Id.ToString());

            Assert.AreEqual(userMoney, expectedAmount);
        }
    }
}
