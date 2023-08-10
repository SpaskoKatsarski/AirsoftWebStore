namespace AirsoftWebStore.Services.Tests.Consumative
{
    using Data;
    using Data.Models;

    public static class ConsumativeDatabaseSeeder
    {
        public static Consumative Consumative;

        public static void SeedDatabaseForConsumative(AirsoftStoreDbContext dbContext)
        {
            Consumative = new Consumative()
            {
                Name = "BBs - NOVRTISCH",
                Description = "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.",
                ImageUrl = "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg",
                Price = 20,
                Quantity = 5,
                IsActive = true
            };

            dbContext.Consumatives.Add(Consumative);
            dbContext.SaveChanges();
        }
    }
}
