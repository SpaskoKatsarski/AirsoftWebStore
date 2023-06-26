namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(this.GenerateCategories());
        }

        private ICollection<Category> GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category = new Category()
            {
                Id = 1,
                Name = "Rifle"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Pistol"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Submachine gun"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Sniper rifle"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Shotgun"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Grenade launcher"
            };

            categories.Add(category);

            return categories;
        }
    }
}
