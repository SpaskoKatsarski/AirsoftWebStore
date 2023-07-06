using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class SeedingEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("07d1eaa9-d28d-4f67-8a85-eb9d1d6ad1b9"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5895eeb6-9f35-42a0-8c80-ea5baf79fa90"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("8080b55c-ba24-4e68-ba7a-dd046945313b"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("dc4b3d97-515c-44ad-bc9f-f0b02cd30612"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2a7bfe5e-0a31-4eb8-b475-aa28b5bc2d78"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("ba9253bf-e194-4289-bd5f-023ecb78ac15"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d5bb69c1-e200-4be2-a9da-a9c246037c61"));

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("28b2c5e2-f2d7-4de5-ae5f-5aa765d33055"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", "CJP-02 Pro Combat Jacket", 149.50m, 7 },
                    { new Guid("e20268ec-19a8-47a7-b86e-6e689bb6b774"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("e215f2c1-90a8-4b3f-96eb-872b785ffe85"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", "Ballistic helmet LHO-01", 472.82m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("14c64fc4-7c3c-4d29-bc5d-d87ab07da132"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("2bca8b86-f111-4037-be93-5477677abcf2"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("64f3d3b5-6b4e-4d99-82ca-6d7be927522d"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("79dce28c-2f12-40e2-b3ff-d2dc6bb92ffe"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("8bddef54-5e77-44b7-862d-2405ca27e488"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("d8b38a8b-56f1-4d37-9e5f-a85d5e3f6f2c"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("e25ce92a-c276-4c23-834b-df22d3339198"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("28b2c5e2-f2d7-4de5-ae5f-5aa765d33055"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("e20268ec-19a8-47a7-b86e-6e689bb6b774"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("e215f2c1-90a8-4b3f-96eb-872b785ffe85"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("14c64fc4-7c3c-4d29-bc5d-d87ab07da132"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("2bca8b86-f111-4037-be93-5477677abcf2"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("64f3d3b5-6b4e-4d99-82ca-6d7be927522d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("79dce28c-2f12-40e2-b3ff-d2dc6bb92ffe"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("8bddef54-5e77-44b7-862d-2405ca27e488"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d8b38a8b-56f1-4d37-9e5f-a85d5e3f6f2c"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e25ce92a-c276-4c23-834b-df22d3339198"));

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("07d1eaa9-d28d-4f67-8a85-eb9d1d6ad1b9"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", false, "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("5895eeb6-9f35-42a0-8c80-ea5baf79fa90"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", false, "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("8080b55c-ba24-4e68-ba7a-dd046945313b"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", false, "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("dc4b3d97-515c-44ad-bc9f-f0b02cd30612"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", false, "GF Custom Division", "8871", 260.57m, 5, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2a7bfe5e-0a31-4eb8-b475-aa28b5bc2d78"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", false, "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("ba9253bf-e194-4289-bd5f-023ecb78ac15"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", false, "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("d5bb69c1-e200-4be2-a9da-a9c246037c61"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", false, "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }
    }
}
