namespace AirsoftWebStore.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gunsmith;
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
        public void SetUp()
        {
            //this.dbContext = new AirsoftStoreDbContext(this.dbOptions);
            //SeedDatabase(this.dbContext);
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnTrueWhenExists()
        {
            string userId = GunsmithUser.Id.ToString();

            bool result = await this.gunsmithService.IsGunsmithAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnFalseWhenIsNot()
        {
            string userId = NormalUser.Id.ToString();

            bool result = await this.gunsmithService.IsGunsmithAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllShouldReturnAllGunsmiths()
        {
            ICollection<GunsmithViewModel> gunsmiths = (ICollection<GunsmithViewModel>)await this.gunsmithService.AllAsync();

            int returnedCount = gunsmiths.Count();
            int actualCount = this.dbContext.Gunsmiths.Count();

            Assert.AreEqual(returnedCount, actualCount);
        }

        [Test]
        public async Task BecomeGunsmithShouldMakeUserGunsmith()
        {
            // Arrange
            string userId = NormalUser.Id.ToString();

            // Act
            await gunsmithService.BecomeGunsmithAsync(userId);
            bool isUserGunsmith = await this.gunsmithService.IsGunsmithAsync(userId);

            // Assert
            Assert.IsFalse(NormalUser.HasGunsmithRequest);
            Assert.IsTrue(isUserGunsmith);
        }

        [Test]
        public async Task RemoveGunsmithShouldRemoveByUserId()
        {
            await gunsmithService.RemoveGunsmithAsync(GunsmithUser.Id.ToString());

            bool isGunsmith = await this.gunsmithService.IsGunsmithAsync(GunsmithUser.Id.ToString());

            Assert.IsFalse(isGunsmith);
        }

        [Test]
        public void RemoveGunsmithWithInvalidUserIdShouldThrowException()
        {
            string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await this.gunsmithService.RemoveGunsmithAsync(invalidId);
            }, "User with the provided ID does not exist!");
        }

        [Test]
        public void RemoveGunsmithWithNonGunsmithIdShouldThrowException()
        {
            string notGunsmithId = NormalUser.Id.ToString();

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await this.gunsmithService.RemoveGunsmithAsync(notGunsmithId);
            }, "Gunsmith with the provided ID does not exist!");
        }

        [Test]
        public async Task RemoveRequestShouldWorkWithExistingUser()
        {
            NormalUser.HasGunsmithRequest = true;

            await gunsmithService.RemoveRequestAsync(NormalUser.Id.ToString());

            Assert.IsFalse(NormalUser.HasGunsmithRequest);
        }
    }
}