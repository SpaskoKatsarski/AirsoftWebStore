namespace AirsoftWebStore.Services.Tests.Cart
{
    using AirsoftWebStore.Data;
    using AirsoftWebStore.Data.Models;

    public static class CartDatabaseSeeder
    {
        public static ApplicationUser User;

        public static Equipment Equipment;
        public static Consumative Consumative;

        public static void SeedDatabaseForCart(AirsoftStoreDbContext dbContext)
        {
            User = new ApplicationUser()
            {
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = false,
                PasswordHash = "testestestestestes1231231232",
                SecurityStamp = "2RC726483DB146C7AB86961EBD8FA68B",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Test",
                LastName = "Testov"
            };

            Equipment = new Equipment()
            {
                Name = "Test-Equipment",
                Description = "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 50,
                Quantity = 3,
                IsActive = true
            };

            Consumative = new Consumative()
            {
                Name = "TEST - BBs - NOVRTISCH",
                Description = "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.",
                ImageUrl = "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg",
                Price = 20,
                Quantity = 2,
                IsActive = true
            };

            dbContext.Users.Add(User);
            dbContext.Equipments.Add(Equipment);
            dbContext.Consumatives.Add(Consumative);

            dbContext.SaveChanges();
        }
    }
}
