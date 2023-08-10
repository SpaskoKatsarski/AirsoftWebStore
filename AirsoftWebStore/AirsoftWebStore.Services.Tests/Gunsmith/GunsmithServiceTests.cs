namespace AirsoftWebStore.Services.Tests.Gunsmith
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Gunsmith;
    using static GunsmithDatabaseSeeder;

    public class GunsmithServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private IGunsmithService gunsmithService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForGunsmith(dbContext);

            gunsmithService = new GunsmithService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureCreated();
            SeedDatabaseForGunsmith(dbContext);
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnTrueWhenExists()
        {
            string userId = GunsmithUser.Id.ToString();

            bool result = await gunsmithService.IsGunsmithAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsGunsmithByUserIdShouldReturnFalseWhenIsNot()
        {
            string userId = NormalUser.Id.ToString();

            bool result = await gunsmithService.IsGunsmithAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AllShouldReturnAllGunsmiths()
        {
            ICollection<GunsmithViewModel> gunsmiths = (ICollection<GunsmithViewModel>)await gunsmithService.AllAsync();

            int returnedCount = gunsmiths.Count();
            int actualCount = dbContext.Gunsmiths.Count();

            Assert.AreEqual(returnedCount, actualCount);
        }

        [Test]
        public async Task BecomeGunsmithShouldMakeUserGunsmith()
        {
            // Arrange
            string userId = NormalUser.Id.ToString();

            // Act
            await gunsmithService.BecomeGunsmithAsync(userId);
            bool isUserGunsmith = await gunsmithService.IsGunsmithAsync(userId);

            // Assert
            Assert.IsFalse(NormalUser.HasGunsmithRequest);
            Assert.IsTrue(isUserGunsmith);
        }

        [Test]
        public async Task RemoveGunsmithShouldRemoveByUserId()
        {
            await gunsmithService.RemoveGunsmithAsync(GunsmithUser.Id.ToString());

            bool isGunsmith = await gunsmithService.IsGunsmithAsync(GunsmithUser.Id.ToString());

            Assert.IsFalse(isGunsmith);
        }

        [Test]
        public void RemoveGunsmithWithInvalidUserIdShouldThrowException()
        {
            string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await gunsmithService.RemoveGunsmithAsync(invalidId);
            }, "User with the provided ID does not exist!");
        }

        [Test]
        public void RemoveGunsmithWithNonGunsmithIdShouldThrowException()
        {
            string notGunsmithId = NormalUser.Id.ToString();

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await gunsmithService.RemoveGunsmithAsync(notGunsmithId);
            }, "Gunsmith with the provided ID does not exist!");
        }

        [Test]
        public async Task RemoveRequestShouldWorkWithExistingUser()
        {
            NormalUser.HasGunsmithRequest = true;

            await gunsmithService.RemoveRequestAsync(NormalUser.Id.ToString());

            Assert.IsFalse(NormalUser.HasGunsmithRequest);
        }

        [Test]
        public void RemoveRequestShouldThrowWhenUserDoesntExist()
        {
            string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await gunsmithService.RemoveRequestAsync(invalidId);
            }, "User with the provided ID does not exist!");
        }

        [Test]
        public async Task AddUserRequestShouldWorkWithExistingUser()
        {
            await gunsmithService.AddUserRequestAsync(NormalUser.Id.ToString());

            Assert.IsTrue(NormalUser.HasGunsmithRequest);
        }

        [Test]
        public void AddUserRequestShouldThrowWhenUserDoesntExist()
        {
            string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await gunsmithService.AddUserRequestAsync(invalidId);
            }, "User with the provided ID does not exist!");
        }

        [Test]
        public async Task HasUserSentRequestShouldReturnTrueWhenHas()
        {
            NormalUser.HasGunsmithRequest = true;

            bool hasSent = await gunsmithService.HasUserSentRequestAsync(NormalUser.Id.ToString());

            Assert.IsTrue(hasSent);
        }

        [Test]
        public async Task HasUserSentRequestShouldReturnFalseWhenHasNot()
        {
            bool hasSent = await gunsmithService.HasUserSentRequestAsync(NormalUser.Id.ToString());

            Assert.IsFalse(hasSent);
        }

        [Test]
        public async Task HasUserSentRequestShouldReturnFalseWhenIdIsNotProvided()
        {
            bool hasSent = await gunsmithService.HasUserSentRequestAsync(null);

            Assert.IsFalse(hasSent);
        }

        [Test]
        public void HasUserSentRequestShouldThrowWhenIdIsInvalid()
        {
            string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await gunsmithService.HasUserSentRequestAsync(invalidId);
            }, "User with the provided ID does not exist!");
        }
    }
}