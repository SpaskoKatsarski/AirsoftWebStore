namespace AirsoftWebStore.Services.Tests.Part
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class PartDatabaseSeeder
    {
        public static Part Part;
        public static Category Category;

        public static void SeedDatabaseForPart(AirsoftStoreDbContext dbContext)
        {
            Category = new Category()
            {
                Id = 1,
                Name = "Rifle-Test"
            };

            Part = new Part()
            {
                Name = "Fess II 1-8x24 Driven Hunt Scope",
                Manufacturer = "Buckler",
                Description = "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp",
                Price = 260.05m,
                Quantity = 3,
                CategoryId = 1,
                IsActive = true
            };

            dbContext.Parts.Add(Part);
            dbContext.Categories.Add(Category);
            dbContext.SaveChanges();
        }
    }
}
