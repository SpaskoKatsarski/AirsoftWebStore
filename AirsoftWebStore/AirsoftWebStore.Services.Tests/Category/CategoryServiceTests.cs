namespace AirsoftWebStore.Services.Tests.Category
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Category;
    using System.Collections.Generic;
    using static CategoryDatabaseSeeder;

    public class CategoryServiceTests
    {
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;
        private AirsoftStoreDbContext dbContext;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForCategory(dbContext);

            categoryService = new CategoryService(dbContext);
        }

        [Test]
        public async Task AllShouldReturnCorrectCount()
        {
            ICollection<CategoryFormViewModel> models = (ICollection<CategoryFormViewModel>)await categoryService.AllAsync();

            int actualCount = models.Count();
            int expectedCount = dbContext.Categories.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task AllNamesShouldReturnCorrectCount()
        {
            ICollection<string> models = (ICollection<string>)await categoryService.AllNamesAsync();

            int actualCount = models.Count();
            int expectedCount = dbContext.Categories.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool result = await categoryService.ExistsByIdAsync(5);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            bool result = await categoryService.ExistsByIdAsync(10);

            Assert.IsFalse(result);
        }
    }
}
