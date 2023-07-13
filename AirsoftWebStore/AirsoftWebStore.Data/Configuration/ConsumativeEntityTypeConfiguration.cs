namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

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

            return consumatives;
        }
    }
}
