using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class UserGunsmithRequestFieldSetToNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("9b7d7220-5c15-40aa-959b-a3b9f52ca712"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("30357673-5c51-4364-86c4-34bc1b75f0ae"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("a8d0dd12-7d3b-4269-8a2e-c0631b6be034"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("ebaaecbb-54b4-4cd6-8d4f-381df1f3e2cb"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("0d71fc90-8cf2-48a2-bd9d-58c46098f8e9"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("2d94bae2-5cb0-4ddd-9803-a64ada1778f7"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("398238a3-f719-4fb6-a121-762e325eb454"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("415f0a35-7c62-4e0b-a0c7-2ba5d2682503"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("4d39b5db-aeb2-422a-a955-93e579984859"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("79cc3172-244f-4bce-aad3-cb88505113ad"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("7dd0b2aa-dd70-41ff-a4d1-65da6cab0d58"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("86eafdec-99b0-4ba7-ad74-14add116e3f4"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("887c01aa-86c5-4f31-9c15-56967c516967"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("b08b882d-6143-4d2c-bc71-d72793c25e33"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("d18f18f3-1603-4e7d-b6d2-f664be4f7212"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("e33969c1-db97-4bcd-bc96-1abd471c954d"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("035a3e92-743a-497c-8f83-5fe6b71844dc"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("5b632fe8-3fe8-41d3-a006-f0d5a3a34e70"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c44ed93d-4dc7-4b91-9dfe-2483bb6f2ca5"));

            migrationBuilder.AlterColumn<bool>(
                name: "HasGunsmithRequest",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("68576a26-205f-4a5c-b5ad-37f5958aa2f8"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0172fc2f-0fe4-4a6e-8051-67111476ede5"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("2aad4078-ccd4-4ec4-9e4a-320e486ac589"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("f7048e0f-606b-4f52-8d39-0d39b47c8ef4"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", "CJP-02 Pro Combat Jacket", 149.50m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("1b83104a-f1f9-4177-bf77-84296fd129ce"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("48fd95a0-5c43-4bde-a1d5-b6c5821a0fb8"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("5208fc15-b6bc-411c-bf51-aea4fa7b88d0"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("57e46f7c-968d-498f-9ab7-19833c459558"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("80919db8-d367-4304-8c7a-ceb13fea0618"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("8a3be399-83fa-4918-bbaa-a719d96a460b"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("a7467d2f-c168-40bf-b9e4-e10708d22aba"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("abd1147e-62d3-4e63-b398-9efce577a19c"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("afc5ad30-8de2-495d-b40c-0ec9318c2caf"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("baecdaf2-f11b-412c-9c13-644d03af0210"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("ca09ab94-98df-4cf2-a660-64084402b990"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("d43eb991-c60f-49d5-9416-1ff69504e9cf"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("31c65fcc-5efc-45b8-88bb-69262d871808"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("bbea2959-ceca-444f-b058-8dc6fcf33f2b"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("d2b7cf8c-3bc1-4612-9473-a3d38b612506"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "HasGunsmithRequest",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("9b7d7220-5c15-40aa-959b-a3b9f52ca712"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", false, "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("30357673-5c51-4364-86c4-34bc1b75f0ae"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", false, "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("a8d0dd12-7d3b-4269-8a2e-c0631b6be034"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", false, "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("ebaaecbb-54b4-4cd6-8d4f-381df1f3e2cb"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", false, "CJP-02 Pro Combat Jacket", 149.50m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("0d71fc90-8cf2-48a2-bd9d-58c46098f8e9"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", false, "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("2d94bae2-5cb0-4ddd-9803-a64ada1778f7"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("398238a3-f719-4fb6-a121-762e325eb454"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", false, "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("415f0a35-7c62-4e0b-a0c7-2ba5d2682503"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", false, "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("4d39b5db-aeb2-422a-a955-93e579984859"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", false, "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("79cc3172-244f-4bce-aad3-cb88505113ad"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", false, "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("7dd0b2aa-dd70-41ff-a4d1-65da6cab0d58"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", false, "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("86eafdec-99b0-4ba7-ad74-14add116e3f4"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", false, "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("887c01aa-86c5-4f31-9c15-56967c516967"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", false, "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("b08b882d-6143-4d2c-bc71-d72793c25e33"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", false, "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("d18f18f3-1603-4e7d-b6d2-f664be4f7212"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("e33969c1-db97-4bcd-bc96-1abd471c954d"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", false, "Specna Arms", "SA-H22", 385.25m, 4, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("035a3e92-743a-497c-8f83-5fe6b71844dc"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", false, "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("5b632fe8-3fe8-41d3-a006-f0d5a3a34e70"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", false, "PTS", "Short Angle Grip", 50.50m, 3 },
                    { new Guid("c44ed93d-4dc7-4b91-9dfe-2483bb6f2ca5"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", false, "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 }
                });
        }
    }
}
