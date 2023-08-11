namespace AirsoftWebStore.Services.Tests.Part
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Part;
    using static PartDatabaseSeeder;

    public class PartServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private IPartService partService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForPart(dbContext);

            partService = new PartService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForPart(dbContext);
        }

        [Test]
        public async Task AddShouldIncreaseTheCountsOfEntities()
        {
            const int expectedCount = 2;

            PartFormViewModel model = new PartFormViewModel()
            {
                Name = "Fess II 1-8x24 Driven Hunt Scope",
                Manufacturer = "Buckler",
                Description = "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp",
                Price = 260.05m,
                Quantity = 3,
                CategoryId = Category.Id
            };

            await this.partService.AddAsync(model);
            int actualCount = dbContext.Parts.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        //[Test]
        //public async Task AllShouldReturnCorrectCount()
        //{
        //    const int expectedCount = 2;

        //    int acutalCount = (ICollection<PartAllViewModel>)(await this.partService.AllAsync()).Count();
        //}

        [Test]
        public async Task GetDetailsShouldReturnCorrectViewModel()
        {
            PartDetailViewModel model = await this.partService.GetDetailsAsync(Part.Id.ToString());

            Assert.AreEqual(model.Id, Part.Id.ToString());
        }

        [Test]
        public async Task ExistsByNameShouldReturnTrueWhenExists()
        {
            bool exists = await this.partService.ExistsByNameAsync(Part.Name);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByNameShouldReturnFalseWhenDoesntExist()
        {
            const string invalidName = "X";

            bool exists = await this.partService.ExistsByNameAsync(invalidName);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool exists = await this.partService.ExistsByIdAsync(Part.Id.ToString());

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            const string invalidId = "X";

            bool exists = await this.partService.ExistsByIdAsync(invalidId);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetForEditShouldReturnCorrectPart()
        {
            PartFormViewModel model = await this.partService.GetPartForEditAsync(Part.Id.ToString());

            Assert.AreEqual(model.Id, Part.Id.ToString());
        }

        [Test]
        public async Task EditShouldWorkCorrectly()
        {
            PartFormViewModel model = new PartFormViewModel()
            {
                Id = Part.Id.ToString(),
                Name = "Edited",
                Manufacturer = "Buckler",
                Description = "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp",
                Price = 100,
                Quantity = 5,
                CategoryId = Category.Id
            };

            await this.partService.EditAsync(model);

            Assert.AreEqual(model.Name, Part.Name.ToString());
            Assert.AreEqual(model.Price, Part.Price);
            Assert.AreEqual(model.Quantity, Part.Quantity);
        }

        [Test]
        public async Task GetForDeleteShouldReturnCorrectModel()
        {
            PartDeleteViewModel model = await this.partService.GetPartForDeleteAsync(Part.Id.ToString());

            Assert.AreEqual(model.Name, Part.Name);
            Assert.AreEqual(model.Category, Part.Category.Name);
            Assert.AreEqual(model.ImageUrl, Part.ImageUrl);
        }

        [Test]
        public async Task DeleteShouldRemoveCorrectly()
        {
            await this.partService.DeleteAsync(Part.Id.ToString());

            Assert.IsFalse(Part.IsActive);
        }

        [Test]
        public async Task GetPartByIdShouldReturnCorrectPart()
        {
            string partId = (await this.partService.GetPartByIdAsync(Part.Id.ToString())).Id.ToString();

            Assert.AreEqual(partId, Part.Id.ToString());
        }
    }
}
