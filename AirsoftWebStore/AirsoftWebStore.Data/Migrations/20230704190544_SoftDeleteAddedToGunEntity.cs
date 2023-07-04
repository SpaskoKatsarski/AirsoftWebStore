using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class SoftDeleteAddedToGunEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("191f5f35-a1b7-4080-8b96-46a34198bdf7"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("890f690b-c608-4ce5-912d-89a3cc9ee082"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("98a09d6f-6df3-479f-af1e-62f3ac5d7378"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("c1f20e9e-d98a-4cbc-97b8-92d5b64e7003"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("122df8fe-4cce-4ba5-8364-496993ddf6f4"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("a6505172-2d65-4d38-a4c3-bee688dda976"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("b8a522f0-ba5c-4a35-b343-4eee3681653f"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Guns",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("0d2420f5-cee0-4ab5-858c-06a48cda2045"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("4e511f7b-4043-4bba-ab1a-810625301b53"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("d8b2fbb2-bf2b-4e1a-840b-58024d508299"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("f409b060-50f7-41b4-af11-3191ec61d1d2"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("780d8444-adcb-4a0f-93a6-2742c38c9b70"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("b0bfac80-8739-42e8-944a-afd156bf6d69"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("d22783cd-505d-4180-b0a2-d069610351b1"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("0d2420f5-cee0-4ab5-858c-06a48cda2045"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("4e511f7b-4043-4bba-ab1a-810625301b53"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("d8b2fbb2-bf2b-4e1a-840b-58024d508299"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("f409b060-50f7-41b4-af11-3191ec61d1d2"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("780d8444-adcb-4a0f-93a6-2742c38c9b70"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("b0bfac80-8739-42e8-944a-afd156bf6d69"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d22783cd-505d-4180-b0a2-d069610351b1"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Guns");

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("191f5f35-a1b7-4080-8b96-46a34198bdf7"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("890f690b-c608-4ce5-912d-89a3cc9ee082"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("98a09d6f-6df3-479f-af1e-62f3ac5d7378"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("c1f20e9e-d98a-4cbc-97b8-92d5b64e7003"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("122df8fe-4cce-4ba5-8364-496993ddf6f4"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("a6505172-2d65-4d38-a4c3-bee688dda976"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("b8a522f0-ba5c-4a35-b343-4eee3681653f"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }
    }
}
