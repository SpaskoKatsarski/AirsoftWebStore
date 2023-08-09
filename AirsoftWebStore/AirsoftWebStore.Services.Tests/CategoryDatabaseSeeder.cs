namespace AirsoftWebStore.Services.Tests
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class CategoryDatabaseSeeder
    {
        public static Category Category;

        public static void SeedDatabaseForCategory(AirsoftStoreDbContext dbContext)
        {
            Category = new Category()
            {
                Id = 5,
                Name = "Test-Rifle"
            };
            dbContext.Categories.Add(Category);

            dbContext.SaveChanges();
        }
    }
}
