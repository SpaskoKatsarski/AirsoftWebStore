namespace AirsoftWebStore.Services.Tests.Gun
{
    using Data;
    using Data.Models;

    public static class GunDatabaseSeeder
    {
        public static Gun Rifle;
        public static Gun Sniper;
        public static Gun Shotgun;

        public static Category RifleCategory;
        public static Category SniperCategory;
        public static Category ShotgunCategory;

        public static void SeedDatabaseForGun(AirsoftStoreDbContext dbContext)
        {
            RifleCategory = new Category()
            {
                Name = "Rifle-Test"
            };

            SniperCategory = new Category()
            {
                Name = "Sniper-Test"
            };

            ShotgunCategory = new Category()
            {
                Name = "Shotgun-Test"
            };

            Rifle = new Gun()
            {
                Name = "Test Rifle",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.",
                ImageUrl = "https://www.zerooneairsoft.com/products_image_15055_0.jpg",
                Year = 2023,
                Price = 250,
                Quantity = 3,
                Category = RifleCategory,
                IsActive = true
            };

            Sniper = new Gun()
            {
                Name = "Test Sniper",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.",
                ImageUrl = "https://www.zerooneairsoft.com/products_image_15055_0.jpg",
                Year = 2022,
                Price = 250,
                Quantity = 3,
                Category = SniperCategory,
                IsActive = true
            };

            Shotgun = new Gun()
            {
                Name = "Test Shotgun",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.",
                ImageUrl = "https://www.zerooneairsoft.com/products_image_15055_0.jpg",
                Year = 2021,
                Price = 250,
                Quantity = 3,
                Category = ShotgunCategory,
                IsActive = true
            };

            dbContext.Guns.AddRange(Rifle, Sniper, Shotgun);
            dbContext.Categories.AddRange(RifleCategory, SniperCategory, ShotgunCategory);
            dbContext.SaveChanges();
        }
    }
}
