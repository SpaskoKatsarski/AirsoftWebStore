namespace AirsoftWebStore.Services.Tests.Gun
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Home;
    using AirsoftWebStore.Web.ViewModels.Gun;
    using static GunDatabaseSeeder;
    using static Common.ErrorMessages.Gun;

    public class GunServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private IGunService gunService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForGun(dbContext);

            gunService = new GunService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForGun(dbContext);
        }

        [Test]
        public async Task Get3WithMostCountsShouldWorkCorrectWith3OrMoreAvailible()
        {
            const int expectedCount = 3;

            ICollection<IndexViewModel> models = (ICollection<IndexViewModel>)await this.gunService.GetTopThreeWithMostCountsAsync();

            int count = models.Count();

            Assert.AreEqual(count, expectedCount);
        }

        [Test]
        public async Task Get3WithMostCountsShouldWorkCorrectWithLessThan3Availible()
        {
            const int expectedCount = 1;

            dbContext.RemoveRange(Sniper, Shotgun);
            dbContext.SaveChanges();

            ICollection<IndexViewModel> models = (ICollection<IndexViewModel>)await this.gunService.GetTopThreeWithMostCountsAsync();

            int count = models.Count();

            Assert.AreEqual(count, expectedCount);
        }

        [Test]
        public async Task AddShouldIncreaseCountOfEntities()
        {
            const int expectedCount = 4;

            GunFormViewModel model = new GunFormViewModel()
            {
                Name = "Test-Replica",
                Manufacturer = "someone",
                Description = "TESTESTEESTTTESTESTEESTTTESTESTEESTT",
                ImageUrl = Sniper.ImageUrl,
                Year = 2020,
                Price = 350,
                Quantity = 2,
                CategoryId = SniperCategory.Id
            };

            await this.gunService.AddAsync(model);
            int actualCount = dbContext.Guns.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task DeleteShouldRemoveEntity()
        {
            await this.gunService.DeleteAsync(Sniper.Id.ToString());

            Assert.IsFalse(Sniper.IsActive);
        }

        [Test]
        public async Task EditShouldApplyChanges()
        {
            GunFormViewModel model = new GunFormViewModel()
            {
                Id = Sniper.Id.ToString(),
                Name = "Test-Sniper-2",
                Manufacturer = "someone",
                Description = "TESTESTEESTTTESTESTEESTTTESTESTEESTT",
                ImageUrl = Sniper.ImageUrl,
                Year = 2020,
                Price = 200,
                Quantity = 2,
                CategoryId = SniperCategory.Id
            };

            await this.gunService.EditAsync(model);

            Assert.AreEqual(Sniper.Name, model.Name);
            Assert.AreEqual(Sniper.Price, model.Price);
            Assert.AreEqual(Sniper.Quantity, model.Quantity);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool exists = await this.gunService.ExistsByIdAsync(Sniper.Id.ToString());

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            const string invalidId = "X";

            bool exists = await this.gunService.ExistsByIdAsync(invalidId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsByNameShouldReturnTrueWhenExists()
        {
            bool exists = await this.gunService.ExistsByNameAsync(Sniper.Name);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByNameShouldReturnFalseWhenDoesntExist()
        {
            const string invalidName = "X";

            bool exists = await this.gunService.ExistsByNameAsync(invalidName);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetDetailsWorkCorrectly()
        {
            GunDetailViewModel model = await this.gunService.GetDetailsAsync(Sniper.Id.ToString());

            Assert.AreEqual(model.Id, Sniper.Id.ToString());
        }

        [Test]
        public void GetDetailsWithInvalidIdShouldThrow()
        {
            const string invalidId = "X";

            Assert.ThrowsAsync<Exception>(async Task () =>
            {
                await this.gunService.GetDetailsAsync(invalidId);
            }, string.Format(GunNotFoundErrorMessage, invalidId));
        }

        [Test]
        public async Task GetForDeleteShouldWorkCorrectly()
        {
            GunDeleteViewModel model = await this.gunService.GetGunForDeleteByIdAsync(Sniper.Id.ToString());

            Assert.AreEqual(model.Name, Sniper.Name);
            Assert.AreEqual(model.Category, Sniper.Category.Name);
            Assert.AreEqual(model.ImageUrl, Sniper.ImageUrl);
        }

        [Test]
        public async Task GetGunForEditShouldWorkCorrectly()
        {
            GunFormViewModel model = await this.gunService.GetGunForEditByIdAsync(Sniper.Id.ToString());

            Assert.AreEqual(model.Id, Sniper.Id.ToString());
        }

        [Test]
        public async Task GetGunByIdShouldReturnCorrectGun()
        {
            string id = (await this.gunService.GetGunByIdAsync(Sniper.Id.ToString())).Id.ToString();

            Assert.AreEqual(id, Sniper.Id.ToString());
        }

        [Test]
        public async Task GetCurrentNameShouldReturnCorrectName()
        {
            string name = await this.gunService.GetCurrentNameAsync(Sniper.Id.ToString());

            Assert.AreEqual(name, Sniper.Name);
        }
    }
}
