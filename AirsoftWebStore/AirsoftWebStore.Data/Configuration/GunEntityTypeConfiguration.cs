namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using AirsoftWebStore.Data.Models;

    public class GunEntityTypeConfiguration : IEntityTypeConfiguration<Gun>
    {
        public void Configure(EntityTypeBuilder<Gun> builder)
        {
            builder
                .HasOne(g => g.Category)
                .WithMany(c => c.Guns)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(this.GenerateGuns());
        }

        private ICollection<Gun> GenerateGuns()
        {
            ICollection<Gun> guns = new HashSet<Gun>();

            Gun gun = new Gun()
            {
                Name = "SA-F02 FLEX HT",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.",
                ImageUrl = "https://www.zerooneairsoft.com/products_image_15055_0.jpg",
                Year = 2021,
                Price = 250,
                Quantity = 3,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "P226",
                Manufacturer = "Dobuel Bell",
                Description = "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.",
                ImageUrl = "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp",
                Year = 2016,
                Price = 90,
                Quantity = 6,
                CategoryId = 2
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "TAC-41 A",
                Manufacturer = "Silverback Airsoft",
                Description = "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp",
                Year = 2022,
                Price = 710.50m,
                Quantity = 3,
                CategoryId = 4
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "8871",
                Manufacturer = "GF Custom Division",
                Description = "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp",
                Year = 2020,
                Price = 260.57m,
                Quantity = 5,
                CategoryId = 5
            };

            guns.Add(gun);

            return guns;
        }
    }
}
