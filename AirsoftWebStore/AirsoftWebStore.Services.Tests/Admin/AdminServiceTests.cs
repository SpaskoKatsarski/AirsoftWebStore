namespace AirsoftWebStore.Services.Tests.Admin
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data;
    using AirsoftWebStore.Services.Contracts;
    using AirsoftWebStore.Web.ViewModels.Admin;
    using static AdminDatabaseSeeder;

    public class AdminServiceTests
    {
        private AirsoftStoreDbContext dbContext;
        private DbContextOptions<AirsoftStoreDbContext> dbOptions;

        private IAdminService adminService;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<AirsoftStoreDbContext>()
                .UseInMemoryDatabase("AirsoftStoreInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new AirsoftStoreDbContext(dbOptions);
            SeedDatabaseForAdmin(dbContext);

            adminService = new AdminService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabaseForAdmin(dbContext);
        }

        [Test]
        public async Task GetAllReqeustsShouldReturnCorrectCount()
        {
            const int expectedRequestsCount = 1;

            ICollection<AllRequestsViewModel> models = (ICollection<AllRequestsViewModel>)await this.adminService.GetAllReqeustsAsync();

            int actualRequestsCount = models.Count();

            Assert.AreEqual(actualRequestsCount, expectedRequestsCount);
        }
    }
}
