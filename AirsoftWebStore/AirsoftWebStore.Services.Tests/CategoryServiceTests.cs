namespace AirsoftWebStore.Services.Tests
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
            this.dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForCategory(this.dbContext);

            this.categoryService = new CategoryService(dbContext);
        }

        [Test]
        public async Task AllShouldReturnCorrectCount()
        {
            ICollection<CategoryFormViewModel> models = (ICollection<CategoryFormViewModel>)await this.categoryService.AllAsync();

            int actualCount = models.Count();
            int expectedCount = this.dbContext.Categories.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task AllNamesShouldReturnCorrectCount()
        {
            ICollection<string> models = (ICollection<string>)await this.categoryService.AllNamesAsync();

            int actualCount = models.Count();
            int expectedCount = this.dbContext.Categories.Count();

            Assert.AreEqual(actualCount, expectedCount);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueWhenExists()
        {
            bool result = await this.categoryService.ExistsByIdAsync(5);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseWhenDoesntExist()
        {
            bool result = await this.categoryService.ExistsByIdAsync(10);

            Assert.IsFalse(result);
        }
    }
}
