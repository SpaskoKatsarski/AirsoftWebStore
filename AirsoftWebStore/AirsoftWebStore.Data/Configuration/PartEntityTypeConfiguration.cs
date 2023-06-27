namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

    public class PartEntityTypeConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Parts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(this.GenerateParts());
        }

        private ICollection<Part> GenerateParts()
        {
            ICollection<Part> parts = new HashSet<Part>();

            Part part = new Part()
            {
                Name = "Fess II 1-8x24 Driven Hunt Scope",
                Manufacturer = "Buckler",
                Description = "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp",
                Price = 260.05m,
                Quantity = 3,
                CategoryId = 4
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "KeyMod Vertical Grip",
                Manufacturer = "SHS",
                Description = "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp",
                Price = 23.65m,
                Quantity = 5,
                CategoryId = 1
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "Short Angle Grip",
                Manufacturer = "PTS",
                Description = "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.",
                ImageUrl = "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp",
                Price = 50.50m,
                Quantity = 3,
                CategoryId = 1
            };

            parts.Add(part);

            return parts;
        }
    }
}
