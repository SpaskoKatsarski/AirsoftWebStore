namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;
    using Microsoft.Extensions.Logging;

    public class ConsumativeEntityTypeConfiguration : IEntityTypeConfiguration<Consumative>
    {
        public void Configure(EntityTypeBuilder<Consumative> builder)
        {
            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder
                .HasData(this.GenerateConsumatives());
        }

        private ICollection<Consumative> GenerateConsumatives() 
        { 
            ICollection<Consumative> consumatives = new HashSet<Consumative>();

            Consumative consumative = new Consumative()
            {
                Name = "BBs",
                Description = "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.",
                ImageUrl = "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg",
                Price = 15.55m,
                Quantity = 8
            };

            consumatives.Add(consumative);

            consumative = new Consumative()
            {
                Name = "Flashbang grenade dummy",
                Description = "Flashbang grenade replica. The body is made of plastic, the spoon, the pin and the spring in the dummy fuse are made of steel.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_Flashbang-grenade-dummy-1152234183_1.webp",
                Price = 11.50m,
                Quantity = 4
            };

            consumatives.Add(consumative);

            consumative = new Consumative()
            {
                Name = "40mm green-gas grenade",
                Description = "The grenade’s diameter is 40mm and  it is made of metal. The green gas grenade is designed to be used with the grenade launcher having the inner diameter of 40mm. The grenade is powered by green-gas. It holds 84 BB pellets.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_40mm-green-gas-grenade-84-BB-pellets-SHS-1152200858_1.webp",
                Price = 38.50m,
                Quantity = 3
            };

            consumatives.Add(consumative);

            consumative = new Consumative()
            {
                Name = "Flashbang grenade dummy with loader - Tan",
                Description = "Flashbang grenade launcher with loader made of plastic.",
                ImageUrl = "https://static1.gunfire.com/eng_pm_Flashbang-grenade-dummy-with-loader-Tan-1152234185_1.webp",
                Price = 12.76m,
                Quantity = 4
            };

            consumatives.Add(consumative);

            consumative = new Consumative()
            {
                Name = "Storm 360 Gen.3 Green Gas Grenade - lime green",
                Description = "A solid gas powered grenade by Action Sport Games, which will be perfect for in-door games  for dispatching larger groups of opponents.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_Storm-360-Gen-3-Green-Gas-Grenade-lime-green-1152230228_1.webp",
                Price = 51.55m,
                Quantity = 6
            };

            consumatives.Add(consumative);

            return consumatives;
        }
    }
}
