namespace AirsoftWebStore.Services.Tests.Gun
{
    using Data;
    using Data.Models;

    public static class GunDatabaseSeeder
    {
        public static Gun Gun;
        public static Category Category;

        public static void SeedDatabaseForPart(AirsoftStoreDbContext dbContext)
        {
            Category = new Category()
            {
                Name = "Rifle-Test"
            };

            Gun = new Gun()
            {
                Name = "Test Gun",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.",
                ImageUrl = "https://www.zerooneairsoft.com/products_image_15055_0.jpg",
                Year = 2021,
                Price = 250,
                Quantity = 3,
                Category = Category,
                IsActive = true
            };

            dbContext.Guns.Add(Gun);
            dbContext.Categories.Add(Category);
            dbContext.SaveChanges();
        }
    }
}
