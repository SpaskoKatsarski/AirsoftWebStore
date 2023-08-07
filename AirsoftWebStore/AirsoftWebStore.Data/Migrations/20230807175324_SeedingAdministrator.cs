using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class SeedingAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("68576a26-205f-4a5c-b5ad-37f5958aa2f8"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("0172fc2f-0fe4-4a6e-8051-67111476ede5"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("2aad4078-ccd4-4ec4-9e4a-320e486ac589"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("f7048e0f-606b-4f52-8d39-0d39b47c8ef4"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("1b83104a-f1f9-4177-bf77-84296fd129ce"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("48fd95a0-5c43-4bde-a1d5-b6c5821a0fb8"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5208fc15-b6bc-411c-bf51-aea4fa7b88d0"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("57e46f7c-968d-498f-9ab7-19833c459558"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("80919db8-d367-4304-8c7a-ceb13fea0618"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("8a3be399-83fa-4918-bbaa-a719d96a460b"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("a7467d2f-c168-40bf-b9e4-e10708d22aba"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("abd1147e-62d3-4e63-b398-9efce577a19c"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("afc5ad30-8de2-495d-b40c-0ec9318c2caf"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("baecdaf2-f11b-412c-9c13-644d03af0210"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("ca09ab94-98df-4cf2-a660-64084402b990"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("d43eb991-c60f-49d5-9416-1ff69504e9cf"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("31c65fcc-5efc-45b8-88bb-69262d871808"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("bbea2959-ceca-444f-b058-8dc6fcf33f2b"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d2b7cf8c-3bc1-4612-9473-a3d38b612506"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), "67b00463-9f95-4dba-b0ef-33eb864fd5a4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Money", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, null, "e0c246c0-4b5b-493c-ac3f-9100a632a9e8", null, false, "Admin", "Adminov", true, null, 0m, null, "ADMIN@SOLDIER.EU", "AQAAAAEAACcQAAAAEHiZhlgY9u1j2LfySib2Jfu1Ttzm/2HuEx+o4OVeKDw6EkGMh+IgGHiG7kEo3J80sQ==", null, false, "1BC726483DA146C7AB96961EBD8FA88B", false, "admin@soldier.eu" });

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("27f48084-e49d-4256-975e-104c28dea628"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9e4921a0-ba45-4c70-806a-2617f5b1752e"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("a0fd2cc1-2503-42dd-8d0e-769461c6b17d"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", "CJP-02 Pro Combat Jacket", 149.50m, 7 },
                    { new Guid("d92f9fc4-11a1-4a11-8028-ef9d2bf70af5"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", "Ballistic helmet LHO-01", 472.82m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("2da5f33c-5428-42a9-aaff-7183206ba259"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("2fcfde6e-82ce-4e3f-89a4-286ddf909ef4"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("44a57551-ea19-48dc-8620-55c755a6586f"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("627f76be-9847-4759-b5a6-f44bc432f9e6"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("73d09406-e36f-49cc-b3ac-dbfc401681a9"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("9adcd9f9-28ec-45d9-935c-1f797e79f272"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("aa01fbbc-5957-4311-a31f-483db93362ba"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("c1e45e44-834a-4bed-8095-db94800b85c4"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("ced130ca-6365-483c-a447-eae3c6b6c9b9"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("db4f5a25-4b98-4e8c-89cc-d0120f2bdbd2"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("e38c5e6f-018b-4001-8fbc-3d83bd9d453a"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("fadf24e5-0fa0-4783-b6ca-117474622467"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "G&G Armament", "SMC-9", 440.25m, 7, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("51e23f85-a2e6-46ee-a71f-8eb65cf40c43"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("72cb408a-9d22-49a9-a461-027264cfdf63"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("bbc684a9-315d-45e3-ae7a-319fceb8fc0a"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") });

            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("27f48084-e49d-4256-975e-104c28dea628"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("9e4921a0-ba45-4c70-806a-2617f5b1752e"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("a0fd2cc1-2503-42dd-8d0e-769461c6b17d"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("d92f9fc4-11a1-4a11-8028-ef9d2bf70af5"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("2da5f33c-5428-42a9-aaff-7183206ba259"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("2fcfde6e-82ce-4e3f-89a4-286ddf909ef4"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("44a57551-ea19-48dc-8620-55c755a6586f"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("627f76be-9847-4759-b5a6-f44bc432f9e6"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("73d09406-e36f-49cc-b3ac-dbfc401681a9"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("9adcd9f9-28ec-45d9-935c-1f797e79f272"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("aa01fbbc-5957-4311-a31f-483db93362ba"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("c1e45e44-834a-4bed-8095-db94800b85c4"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("ced130ca-6365-483c-a447-eae3c6b6c9b9"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("db4f5a25-4b98-4e8c-89cc-d0120f2bdbd2"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("e38c5e6f-018b-4001-8fbc-3d83bd9d453a"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("fadf24e5-0fa0-4783-b6ca-117474622467"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("51e23f85-a2e6-46ee-a71f-8eb65cf40c43"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("72cb408a-9d22-49a9-a461-027264cfdf63"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("bbc684a9-315d-45e3-ae7a-319fceb8fc0a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"));

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("68576a26-205f-4a5c-b5ad-37f5958aa2f8"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", false, "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0172fc2f-0fe4-4a6e-8051-67111476ede5"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", false, "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("2aad4078-ccd4-4ec4-9e4a-320e486ac589"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", false, "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("f7048e0f-606b-4f52-8d39-0d39b47c8ef4"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", false, "CJP-02 Pro Combat Jacket", 149.50m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("1b83104a-f1f9-4177-bf77-84296fd129ce"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", false, "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("48fd95a0-5c43-4bde-a1d5-b6c5821a0fb8"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", false, "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("5208fc15-b6bc-411c-bf51-aea4fa7b88d0"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", false, "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("57e46f7c-968d-498f-9ab7-19833c459558"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", false, "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("80919db8-d367-4304-8c7a-ceb13fea0618"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", false, "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("8a3be399-83fa-4918-bbaa-a719d96a460b"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", false, "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("a7467d2f-c168-40bf-b9e4-e10708d22aba"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", false, "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("abd1147e-62d3-4e63-b398-9efce577a19c"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("afc5ad30-8de2-495d-b40c-0ec9318c2caf"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", false, "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("baecdaf2-f11b-412c-9c13-644d03af0210"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", false, "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("ca09ab94-98df-4cf2-a660-64084402b990"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("d43eb991-c60f-49d5-9416-1ff69504e9cf"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", false, "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("31c65fcc-5efc-45b8-88bb-69262d871808"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", false, "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("bbea2959-ceca-444f-b058-8dc6fcf33f2b"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", false, "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("d2b7cf8c-3bc1-4612-9473-a3d38b612506"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", false, "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }
    }
}
