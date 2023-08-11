namespace AirsoftWebStore.Services.Tests.User
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using static UserDatabaseSeeder;
    using AirsoftWebStore.Web.ViewModels.User;

    public class UserServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForUser(dbContext);

            userService = new UserService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForUser(dbContext);
        }

        [Test]
        public async Task AllShouldReturnCorrectCount()
        {
            const int expectedCount = 2;

            ICollection<UserViewModel> models = (ICollection<UserViewModel>)await this.userService.AllAsync();

            int count = models.Count();

            Assert.AreEqual(count, expectedCount);
        }

        [Test]
        public async Task AllShouldDifferentiateGunsmiths()
        {
            const string gunsmithEmail = "test2@test.com";

            IEnumerable<UserViewModel> models = await this.userService.AllAsync();
            UserViewModel gunsmithModel = models.First(m => m.Email == gunsmithEmail);

            Assert.IsTrue(gunsmithModel.IsGunsmith);
        }

        [Test]
        public async Task GetFullNameByEmailShouldReturnFullName()
        {
            string expectedFullName = $"{NormalUser.FirstName} {NormalUser.LastName}";

            string actualName = await this.userService.GetFullNameByEmailAsync(NormalUser.Email);

            Assert.AreEqual(actualName, expectedFullName);
        }
    }
}
