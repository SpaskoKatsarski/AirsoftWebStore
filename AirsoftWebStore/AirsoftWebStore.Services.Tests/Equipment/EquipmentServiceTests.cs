namespace AirsoftWebStore.Services.Tests.Equipment
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Equipment;
    using static ConsumativeDatabaseSeeder;

    public class ConsumativeServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private IEquipmentService equipmentService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
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
            SeedDatabaseForEquipment(this.dbContext);
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

            int actualCount = dbContext.Equipments.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task EditShouldWorkCorrectly()
        {
            const string expectedName = "Test";

            EquipmentFormViewModel model = new EquipmentFormViewModel()
            {
                Id = Equipment.Id.ToString(),
                Name = "Test",
                Description = "Testtestetetetetetetaetetetetetetetetetetetetetete",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 200,
                Quantity = 5
            };

            await this.equipmentService.EditAsync(model);

            string actualName = dbContext.Equipments.Find(Guid.Parse(Equipment.Id.ToString()))!.Name;

            Assert.AreEqual(actualName, expectedName);
        }

        [Test]
        public async Task DeleteShouldWorkCorrectly()
        {
            await this.equipmentService.DeleteAsync(Equipment.Id.ToString());
            Assert.IsFalse(Equipment.IsActive);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool result = await this.equipmentService.ExistsByIdAsync(Equipment.Id.ToString());

            Assert.IsTrue(result);
        }
    }
}
