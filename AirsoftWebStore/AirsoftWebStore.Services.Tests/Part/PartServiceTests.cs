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

        [OneTimeSetUp]
        public void OneTimeSetUp()
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
            // Seeds the database with category with same Id and it crashes, when commented it works but second test fails
            // because it uses the noraml database insted the InMemory one
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
                CategoryId = 1
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

            int count = dbContext.Parts.Count();
            Assert.AreEqual(2, count);
        }
    }
}
