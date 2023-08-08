namespace AirsoftWebStore.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using static DatabaseSeeder;

    public class GunsmithServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private IGunsmithService gunsmithService;

        public GunsmithServiceTests()
        {

        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new AirsoftStoreDbContext(this.dbOptions);
            SeedDatabase(this.dbContext);

            this.gunsmithService = new GunsmithService(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnTrueWhenExists()
        {
            string userId = GunsmithUser.Id.ToString();

            bool result = await this.gunsmithService.IsGunsmithAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnFalseWhenDoesntExist()
        {
            string userId = NormalUser.Id.ToString();

            bool result = await this.gunsmithService.IsGunsmithAsync(userId);

            Assert.IsFalse(result);
        }
    }
}