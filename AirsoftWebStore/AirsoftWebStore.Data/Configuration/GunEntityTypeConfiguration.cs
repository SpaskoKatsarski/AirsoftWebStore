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
                .Property(g => g.IsActive)
                .HasDefaultValue(true);

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

            gun = new Gun()
            {
                Name = "SA-H22",
                Manufacturer = "Specna Arms",
                Description = "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp",
                Year = 2021,
                Price = 385.25m,
                Quantity = 4,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SA-C10 PDW CORE",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp",
                Year = 2020,
                Price = 165.50m,
                Quantity = 7,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SA-C05 CORE",
                Manufacturer = "Specna Arms",
                Description = "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp",
                Year = 2018,
                Price = 165.40m,
                Quantity = 4,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SA-C22 CORE",
                Manufacturer = "Specna Arms",
                Description = "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.",
                ImageUrl = "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp",
                Year = 2022,
                Price = 180.23m,
                Quantity = 6,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SA-H11 ONE",
                Manufacturer = "Specna Arms",
                Description = "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.",
                ImageUrl = "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp",
                Year = 2019,
                Price = 303.54m,
                Quantity = 8,
                CategoryId = 1
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SW-04",
                Manufacturer = "Snow Wolf",
                Description = "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp",
                Year = 2019,
                Price = 172.42m,
                Quantity = 5,
                CategoryId = 4
            };
            
            guns.Add(gun);

            gun = new Gun()
            {
                Name = "SMC-9",
                Manufacturer = "G&G Armament",
                Description = "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_SMC-9-Submachine-Gun-Replica-Black-1152226182_1.webp",
                Year = 2021,
                Price = 440.25m,
                Quantity = 7,
                CategoryId = 4
            };

            guns.Add(gun);

            gun = new Gun()
            {
                Name = "GL-06",
                Manufacturer = "ASG",
                Description = "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp",
                Year = 2016,
                Price = 205.56m,
                Quantity = 4,
                CategoryId = 6
            };

            guns.Add(gun);

            return guns;
        }
    }
}
