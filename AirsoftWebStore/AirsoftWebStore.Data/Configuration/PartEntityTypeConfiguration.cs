namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;
    using System.Numerics;
    using System.Threading;

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
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

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

            part = new Part()
            {
                Name = "Aluminum KeyMod Angled Forward Grip",
                Manufacturer = "METAL",
                Description = "A forward grip made of aluminum compatible with handguards featuring the KEYMOD mounting system.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_Aluminum-KeyMod-Angled-Forward-Grip-Black-1152227182_1.webp",
                Price = 15.60m,
                Quantity = 5,
                CategoryId = 1
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "Red Dot 1x30 Reflex Sight Replica",
                Manufacturer = "THETA OPTICS",
                Description = "Theta Optics Red Dot 1x30 reflex sight is enclosed in a metal casing and powered by a CR2032 battery as well as allows to use a green or red dot during both day and night operations. The aimpoint can be smoothly regulated vertically and horizontally.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_Red-Dot-1x30-Reflex-Sight-Replica-Black-1152205530_1.webp",
                Price = 26.50m,
                Quantity = 4,
                CategoryId = 1
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "HM0321 Lightweight Polymer Stock",
                Manufacturer = "DOUBLE BELL",
                Description = "A light, adjustable stock made of polymer, compatible with any replica equipped with an AR15 buffer tube.",
                ImageUrl = "https://static1.gunfire.com/eng_pm_HM0321-Lightweight-Polymer-Stock-for-M4-M16-Replicas-Tan-1152227562_1.webp",
                Price = 21.50m,
                Quantity = 8,
                CategoryId = 1
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "Complete Hop-Up Chamber with 6.03mm 370mm S+Barrel",
                Manufacturer = "TNT",
                Description = "Complete aluminum Hop-Up chamber and a precision 6,03mm stainless steel barrel made in CNC technology.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Complete-Hop-Up-Chamber-with-6-03mm-370mm-S-Barrel-for-VFC-BCM-MCMR-Replicas-1152232630_1.webp",
                Price = 130,
                Quantity = 4,
                CategoryId = 1
            };

            parts.Add(part);

            part = new Part()
            {
                Name = "JG MP5SD Silencer",
                Manufacturer = "JG WORKS",
                Description = "This noise reduction is like nothing else. Really helpful on the battlefield and won't bother you, because it is really light.",
                ImageUrl = "https://static1.gunfire.com/eng_pm_JG-MP5SD-Silencer-part-069-1152217123_1.webp",
                Price = 18.50m,
                Quantity = 6,
                CategoryId = 1
            };

            parts.Add(part);

            return parts;
        }
    }
}
