namespace AirsoftWebStore.Services.Tests.Equipment
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Equipment;
    using static EquipmentDatabaseSeeder;

    public class EquipmentServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private IEquipmentService equipmentService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForEquipment(dbContext);

            equipmentService = new EquipmentService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task AddShouldWorkCorrectly()
        {
            const int expectedCount = 2;

            EquipmentFormViewModel model = new EquipmentFormViewModel()
            {
                Name = "Test",
                Description = "Testtestetetetetetetaetetetetetetetetetetetetetete",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 200,
                Quantity = 5
            };

            await this.equipmentService.AddAsync(model);

            int count = dbContext.Equipments.Count();

            Assert.AreEqual(count, expectedCount);
        }

        // TODO: Check why in the service the methods do not execute and directly returns into the test method
        [Test]
        public async Task EditShouldWorkCorrectly()
        {
            const string expectedName = "Test";

            EquipmentFormViewModel model = new EquipmentFormViewModel()
            {
                Id = "be744b7acfef47f1a3f5fce7d1914a35",
                Name = "Test",
                Description = "Testtestetetetetetetaetetetetetetetetetetetetetete",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 200,
                Quantity = 5
            };

            await this.equipmentService.EditAsync(model);

            string actualName = dbContext.Equipments.Find(Guid.Parse("be744b7acfef47f1a3f5fce7d1914a35"))!.Name;

            Assert.AreEqual(actualName, expectedName);
        }

        [Test]
        public async Task DeleteShouldWorkCorrectly()
        {
            await this.equipmentService.DeleteAsync("be744b7acfef47f1a3f5fce7d1914a35");
            Assert.IsFalse(Equipment.IsActive);
        }
    }
}
