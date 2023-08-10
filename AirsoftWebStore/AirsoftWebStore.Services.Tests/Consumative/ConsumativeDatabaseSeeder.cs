namespace AirsoftWebStore.Services.Tests.Consumative
{
    using Data;
    using Data.Models;

    public class ConsumativeDatabaseSeeder
    {
        public static Equipment Equipment;

        public static void SeedDatabaseForEquipment(AirsoftStoreDbContext dbContext)
        {
            Equipment = new Equipment()
            {
                Id = Guid.Parse("be744b7acfef47f1a3f5fce7d1914a35"),
                Name = "Large tear - off first aid kit",
                Description = "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 10.75m,
                Quantity = 10,
                IsActive = true
            };

            dbContext.Add(Equipment);
            dbContext.SaveChanges();
        }
    }
}
