namespace AirsoftWebStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;

    using AirsoftWebStore.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder
                .Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder
                .HasData(this.GenerateEquipment());
        }

        private ICollection<Equipment> GenerateEquipment()
        {
            ICollection<Equipment> equipmentItems = new HashSet<Equipment>();

            Equipment equipment = new Equipment()
            {
                Name = "Large tear - off first aid kit",
                Description = "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp",
                Price = 10.75m,
                Quantity = 10
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "CJP-02 Pro Combat Jacket",
                Description = "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.",
                ImageUrl = "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp",
                Price = 149.50m,
                Quantity = 7
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "Ballistic helmet LHO-01",
                Description = "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.",
                ImageUrl = "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp",
                Price = 472.82m,
                Quantity = 8
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "Tactical HD-16 Bluetooth Active Headset",
                Description = "Advanced active headset powered by a built-in battery.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_Tactical-HD-16-Bluetooth-Active-Headset-Olive-1152234035_1.webp",
                Price = 123.50m,
                Quantity = 3
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "Bowman Elite II headset",
                Description = "The Bowman Elite II headset. The elastic head strap guarantees a proper placement of the headset on the head.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_Bowman-Elite-II-headset-FG-1152195615_1.webp",
                Price = 18.30m,
                Quantity = 6
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "Tactical headset ERM",
                Description = "The ERM Headset is made out of durable plastic and metal. The ear pads and the headband padding have been equipped with covers to ensure high user comfort.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_Tactical-headset-ERM-Black-1152234028_1.webp",
                Price = 60.45m,
                Quantity = 9
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "Quick Release Plate Carrier Tactical Vest",
                Description = "A Plate Carrier tactical vest made of durable nylon by GFC Tactical. The vest is adapted to carrying a set of ballistic inserts and its compatibility with MOLLE / PALS load-bearing system enables the attachment and any configuration of additional pouches, pockets or bags.",
                ImageUrl = "https://static3.gunfire.com/eng_pm_Quick-Release-Plate-Carrier-Tactical-Vest-Tan-1152228378_1.webp",
                Price = 74.80m,
                Quantity = 10
            };

            equipmentItems.Add(equipment);

            equipment = new Equipment()
            {
                Name = "VX Buckle Up Mag Rig Panel",
                Description = "A panel by Viper Tactical made of durable nylon. The panel is dedicated for tactical vests in Buckle Up system and attachable using a hook and loop fastener and snap buckles.",
                ImageUrl = "https://static5.gunfire.com/eng_pm_VX-Buckle-Up-Mag-Rig-Panel-Coyote-Brown-1152227952_1.webp",
                Price = 40.70m,
                Quantity = 6
            };

            equipmentItems.Add(equipment);
            
            return equipmentItems;
        }
    }
}
