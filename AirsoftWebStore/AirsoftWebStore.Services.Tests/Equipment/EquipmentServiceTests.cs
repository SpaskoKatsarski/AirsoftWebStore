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

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            const string invalidId = "X";

            bool result = await this.equipmentService.ExistsByIdAsync(invalidId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task ExistsByNameShouldReturnTrueWhenExists()
        {
            bool result = await this.equipmentService.ExistsByNameAsync(Equipment.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByNameShouldReturnFalseWhenDoesntExist()
        {
            const string invalidName = "X";

            bool result = await this.equipmentService.ExistsByNameAsync(invalidName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetForDetailsShouldReturnViewModelWithSameId()
        {
            EquipmentDetailsViewModel model = await this.equipmentService.GetForDetailsAsync(Equipment.Id.ToString());

            Assert.AreEqual(model.Id, Equipment.Id.ToString());
        }

        [Test]
        public async Task GetForEditShouldReturnViewModelWithSameId()
        {
            EquipmentFormViewModel model = await this.equipmentService.GetForEditAsync(Equipment.Id.ToString());

            Assert.AreEqual(model.Id, Equipment.Id.ToString());
        }

        [Test]
        public async Task GetForDeleteShouldReturnViewModelWithSameId()
        {
            EquipmentDeleteViewModel model = await this.equipmentService.GetForDeleteAsync(Equipment.Id.ToString());

            string id = dbContext.Equipments
                .Where(e => e.Name == model.Name && e.Id.ToString() == Equipment.Id.ToString())
                .First()
                .Id.ToString();

            Assert.AreEqual(id, Equipment.Id.ToString());
        }

        [Test]
        public async Task GetCurrentNameShouldWorkCorrect()
        {
            string actualName = await this.equipmentService.GetCurrentNameAsync(Equipment.Id.ToString());

            Assert.AreEqual(actualName, Equipment.Name);
        }

        [Test]
        public async Task GetEquipmentByIdShouldReturnCorrectEquipment()
        {
            Data.Models.Equipment equipment = await this.equipmentService.GetEquipmentByIdAsync(Equipment.Id.ToString());

            Assert.AreEqual(equipment.Id.ToString(), Equipment.Id.ToString());
        }
    }
}
