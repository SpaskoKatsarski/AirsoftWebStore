using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class UserFirstAndLastNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("d42bc592-3212-4b28-a0f6-046d8cd1d098"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("4788270c-d4a9-480e-80cf-9504a60ea992"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("92b7d8f2-6e80-478c-9135-3d1f0023bd31"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("9e7913ae-d3df-4533-ad17-9e13a12cec1d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("0aaf4b10-1fe9-4712-8819-b5725156fb38"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("3173e7ca-ba92-40a9-b493-4db4876f5c6d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("4fe50dfd-5272-4280-9791-2025f9ee0b48"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5e97c695-4658-48a1-a1c0-9e6ade122e08"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("6b097fe2-b034-4e3f-a568-894ea3b47548"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("7d35ab56-1d93-4be0-b2a2-7849f1d9501c"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("99ec7ac4-252c-4c37-a52a-29ace64d3bd8"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("9c43732b-a273-452d-9426-7b576731fd8b"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("b26196b0-cf59-454d-9ecb-6635a8d01717"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("b99873b6-463b-4a45-adcb-162387e3ad10"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("c04f4852-93ef-4f80-9213-06efdcd42358"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("c68f7294-eade-41c6-8315-cbf652ca9105"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("25865693-0cd9-4d22-93d0-1749f06b5e11"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("558b8476-5680-4a33-868f-6e37d123eac2"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e963528a-671e-4e3b-9bd9-b911eefeb17c"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("b820364c-4b1c-4589-91f3-2a07e3599d93"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("6c919d2f-4081-47e0-b951-b5819480c4e5"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", "CJP-02 Pro Combat Jacket", 149.50m, 7 },
                    { new Guid("8cff301b-b09a-46a9-8ed7-c9a763e7484c"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("ad8426ec-d89a-44de-844c-2dfa6b000997"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", "Ballistic helmet LHO-01", 472.82m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("11051b36-518e-4513-9ff8-5bdc7ef39c5d"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("33cfd497-8b18-4f91-b102-0d0b9c12ecbd"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("61e1ac37-b903-40b3-b225-50f622c39a04"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("74d1203c-5b1e-4da4-8fca-215754ce095d"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("919e6768-121a-4b05-87a8-26b3221f7e38"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("aa1d1649-7f7d-4479-ae45-cf6ce77a01b6"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("af1ef83a-4fd6-47af-ab2d-3f6db801b012"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("b86db363-c618-437f-8dfa-1a1e9675d80e"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("be3eee04-5499-41e6-918b-58e0179127f6"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("daac83ba-b067-48c4-973c-5d7b0c00802b"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("df014dcb-7ea2-4da8-8c97-cc1ba0574109"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("dfedf595-2d7f-44bb-ad2a-1c467709c595"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("12783952-7234-4058-b1d8-fbe5304a3905"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("4d57a508-5daa-417e-8d70-708e0f175aee"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("deae91a4-db03-4a7a-9483-3454d56c4bb1"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("b820364c-4b1c-4589-91f3-2a07e3599d93"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("6c919d2f-4081-47e0-b951-b5819480c4e5"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("8cff301b-b09a-46a9-8ed7-c9a763e7484c"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("ad8426ec-d89a-44de-844c-2dfa6b000997"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("11051b36-518e-4513-9ff8-5bdc7ef39c5d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("33cfd497-8b18-4f91-b102-0d0b9c12ecbd"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("61e1ac37-b903-40b3-b225-50f622c39a04"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("74d1203c-5b1e-4da4-8fca-215754ce095d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("919e6768-121a-4b05-87a8-26b3221f7e38"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("aa1d1649-7f7d-4479-ae45-cf6ce77a01b6"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("af1ef83a-4fd6-47af-ab2d-3f6db801b012"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("b86db363-c618-437f-8dfa-1a1e9675d80e"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("be3eee04-5499-41e6-918b-58e0179127f6"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("daac83ba-b067-48c4-973c-5d7b0c00802b"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("df014dcb-7ea2-4da8-8c97-cc1ba0574109"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("dfedf595-2d7f-44bb-ad2a-1c467709c595"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("12783952-7234-4058-b1d8-fbe5304a3905"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("4d57a508-5daa-417e-8d70-708e0f175aee"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("deae91a4-db03-4a7a-9483-3454d56c4bb1"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("d42bc592-3212-4b28-a0f6-046d8cd1d098"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", false, "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("4788270c-d4a9-480e-80cf-9504a60ea992"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", false, "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("92b7d8f2-6e80-478c-9135-3d1f0023bd31"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", false, "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("9e7913ae-d3df-4533-ad17-9e13a12cec1d"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", false, "CJP-02 Pro Combat Jacket", 149.50m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("0aaf4b10-1fe9-4712-8819-b5725156fb38"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("3173e7ca-ba92-40a9-b493-4db4876f5c6d"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", false, "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("4fe50dfd-5272-4280-9791-2025f9ee0b48"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", false, "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("5e97c695-4658-48a1-a1c0-9e6ade122e08"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", false, "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("6b097fe2-b034-4e3f-a568-894ea3b47548"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", false, "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("7d35ab56-1d93-4be0-b2a2-7849f1d9501c"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", false, "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("99ec7ac4-252c-4c37-a52a-29ace64d3bd8"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("9c43732b-a273-452d-9426-7b576731fd8b"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", false, "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("b26196b0-cf59-454d-9ecb-6635a8d01717"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", false, "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("b99873b6-463b-4a45-adcb-162387e3ad10"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", false, "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("c04f4852-93ef-4f80-9213-06efdcd42358"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", false, "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("c68f7294-eade-41c6-8315-cbf652ca9105"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", false, "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("25865693-0cd9-4d22-93d0-1749f06b5e11"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", false, "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("558b8476-5680-4a33-868f-6e37d123eac2"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", false, "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("e963528a-671e-4e3b-9bd9-b911eefeb17c"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", false, "SHS", "KeyMod Vertical Grip", 23.65m, 5 }
                });
        }
    }
}
