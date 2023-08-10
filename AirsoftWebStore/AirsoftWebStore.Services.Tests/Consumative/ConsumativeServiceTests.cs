namespace AirsoftWebStore.Services.Tests.Consumative
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Consumative;
    using static ConsumativeDatabaseSeeder;

    public class ConsumativeServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private IConsumativeService consumativeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForConsumative(dbContext);

            consumativeService = new ConsumativeService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForConsumative(this.dbContext);
        }

        [Test]
        public async Task AddShouldWorkCorrectly()
        {
            const int expectedCount = 2;

            ConsumativeFormViewModel model = new ConsumativeFormViewModel()
            {
                Name = "Test",
                Description = "Testtestetetetetetetaetetetetetetetetetetetetetete",
                ImageUrl = "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg",
                Price = 200,
                Quantity = 5
            };

            await this.consumativeService.AddAsync(model);

            int actualCount = dbContext.Consumatives.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task EditShouldWorkCorrectly()
        {
            const string expectedName = "Test";

            ConsumativeFormViewModel model = new ConsumativeFormViewModel()
            {
                Id = Consumative.Id.ToString(),
                Name = "Test",
                Description = "Testtestetetetetetetaetetetetetetetetetetetetetete",
                ImageUrl = "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg",
                Price = 200,
                Quantity = 5
            };

            await this.consumativeService.EditAsync(model);

            string actualName = dbContext.Consumatives.Find(Guid.Parse(Consumative.Id.ToString()))!.Name;

            Assert.AreEqual(actualName, expectedName);
        }

        [Test]
        public async Task DeleteShouldWorkCorrectly()
        {
            await this.consumativeService.DeleteAsync(Consumative.Id.ToString());
            Assert.IsFalse(Consumative.IsActive);
        }

        [Test]
        public async Task GetForDetailsShouldWorkCorrectly()
        {
            ConsumativeDetailsViewModel model = await this.consumativeService.GetForDetailsAsync(Consumative.Id.ToString());

            Assert.AreEqual(model.Id, Consumative.Id.ToString());
        }

        [Test]
        public async Task GetForEditShouldWorkCorrectly()
        {
            ConsumativeFormViewModel model = await this.consumativeService.GetForEditAsync(Consumative.Id.ToString());

            Assert.AreEqual(model.Id.ToString(), Consumative.Id.ToString());
        }

        [Test]
        public async Task GetForDeleteShouldWorkCorrectly()
        {
            ConsumativeDeleteViewModel model = await this.consumativeService.GetForDeleteAsync(Consumative.Id.ToString());

            string id = dbContext.Consumatives
                .Where(e => e.Name == model.Name && e.Id.ToString() == Consumative.Id.ToString())
                .First()
                .Id.ToString();

            Assert.AreEqual(id, Consumative.Id.ToString());
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool exists = await this.consumativeService.ExistsByIdAsync(Consumative.Id.ToString());

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            const string invalidId = "X";

            bool exists = await this.consumativeService.ExistsByIdAsync(invalidId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsByNameAsyncShouldReturnTrueWhenExists()
        {
            bool exists = await this.consumativeService.ExistsByNameAsync(Consumative.Name);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByNameAsyncShouldReturnFalseWhenDoesntExist()
        {
            const string invalidName = "X";

            bool result = await this.consumativeService.ExistsByNameAsync(invalidName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetCurrentNameShouldReturnCorrectName()
        {
            string name = await this.consumativeService.GetCurrentNameAsync(Consumative.Id.ToString());

            Assert.AreEqual(name, Consumative.Name);
        }

        [Test]
        public async Task GetConsumativeByIdShouldWorkCorrectly()
        {
            Data.Models.Consumative consumative = await this.consumativeService.GetConsumativeByIdAsync(Consumative.Id.ToString());

            Assert.AreEqual(consumative.Id.ToString(), Consumative.Id.ToString());
        }
    }
}
