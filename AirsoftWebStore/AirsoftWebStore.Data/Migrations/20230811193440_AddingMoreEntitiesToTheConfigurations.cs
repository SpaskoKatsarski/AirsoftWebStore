using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirsoftWebStore.Data.Migrations
{
    public partial class AddingMoreEntitiesToTheConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("56491455-2840-4e5e-ac29-85e7867a4edc"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("3a39ca4e-eea9-4740-a657-1ff5513a6e15"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("91f48e04-f322-4fea-a061-22240df3ad0e"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("f59f1358-3afd-4bca-9b69-bdba346c1b03"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("07ee7047-9f39-4e29-9e3e-29fa740fb812"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("0ccf64bd-d775-462b-9867-c46e39833dc8"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("21b7d5d6-ab04-4477-8742-0ebffe72380c"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("260641db-e5fc-4ed7-b092-03171177f399"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("308ed68d-b8ae-44c3-b32b-22fe9026e897"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("51736c52-b211-4e86-a29b-76e1cc4b3c2a"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5768eb49-71fd-4d53-98a1-98c485100ca8"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("6a29f6b6-9c83-4777-86d9-9b2fd8684a57"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("bde5cb59-7fb9-4cdb-b9c0-3b1345f5b19d"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("c18c1f4a-1cd6-4746-a940-9b9e50c892f0"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("e76b7699-77fc-454b-9f10-f004a025bb46"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("f71a0c7b-1080-479c-bc6d-f123242b5b67"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2643cdf8-4f0d-476e-bf84-57462f75fca0"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("9b25c046-de47-46d4-a0d5-f4d23f783c87"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("b2c5520c-7b1b-438c-97f2-149213f9ffbc"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "7d745425-08cf-4566-8c8f-76469c9f3dda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7dfb3c69-c935-43df-a27b-668afb091f5a", "AQAAAAEAACcQAAAAEF78kWFknigxhjR5fhkU480/22khPVlEuJ/l5L4uJZp6TiwBUmbTSaeAbzt2OwBpZg==" });

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0c83291a-e1c7-4639-90b1-74d6560afaee"), "Flashbang grenade launcher with loader made of plastic.", "https://static1.gunfire.com/eng_pm_Flashbang-grenade-dummy-with-loader-Tan-1152234185_1.webp", "Flashbang grenade dummy with loader - Tan", 12.76m, 4 },
                    { new Guid("0d376cfd-d367-4401-8f2b-b3367c098ef9"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", "BBs", 15.55m, 8 },
                    { new Guid("5a4f16f5-5183-4dc6-939f-92258369f495"), "Flashbang grenade replica. The body is made of plastic, the spoon, the pin and the spring in the dummy fuse are made of steel.", "https://static5.gunfire.com/eng_pm_Flashbang-grenade-dummy-1152234183_1.webp", "Flashbang grenade dummy", 11.50m, 4 },
                    { new Guid("63cc50ff-66c3-49d1-9e40-7ecd0dbafd08"), "The grenade’s diameter is 40mm and  it is made of metal. The green gas grenade is designed to be used with the grenade launcher having the inner diameter of 40mm. The grenade is powered by green-gas. It holds 84 BB pellets.", "https://static3.gunfire.com/eng_pm_40mm-green-gas-grenade-84-BB-pellets-SHS-1152200858_1.webp", "40mm green-gas grenade", 38.50m, 3 },
                    { new Guid("9aa8283e-1014-485f-9e6b-2324cd204284"), "A solid gas powered grenade by Action Sport Games, which will be perfect for in-door games  for dispatching larger groups of opponents.", "https://static3.gunfire.com/eng_pm_Storm-360-Gen-3-Green-Gas-Grenade-lime-green-1152230228_1.webp", "Storm 360 Gen.3 Green Gas Grenade - lime green", 51.55m, 6 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("1938aaa9-aa2f-4f04-a6f8-e91a65b6ee26"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", "Large tear - off first aid kit", 10.75m, 10 },
                    { new Guid("1e7fee53-65d8-46ee-a075-ede3e1a2825a"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("5bb85faa-2c1e-4c8e-8faa-195d05f8fa91"), "A Plate Carrier tactical vest made of durable nylon by GFC Tactical. The vest is adapted to carrying a set of ballistic inserts and its compatibility with MOLLE / PALS load-bearing system enables the attachment and any configuration of additional pouches, pockets or bags.", "https://static3.gunfire.com/eng_pm_Quick-Release-Plate-Carrier-Tactical-Vest-Tan-1152228378_1.webp", "Quick Release Plate Carrier Tactical Vest", 74.80m, 10 },
                    { new Guid("6ac2fbb9-2d8f-49c5-8ae8-2bb39ad1e7d1"), "The Bowman Elite II headset. The elastic head strap guarantees a proper placement of the headset on the head.", "https://static3.gunfire.com/eng_pm_Bowman-Elite-II-headset-FG-1152195615_1.webp", "Bowman Elite II headset", 18.30m, 6 },
                    { new Guid("9f73713a-91c0-4913-b9f4-604cdd0f592b"), "A panel by Viper Tactical made of durable nylon. The panel is dedicated for tactical vests in Buckle Up system and attachable using a hook and loop fastener and snap buckles.", "https://static5.gunfire.com/eng_pm_VX-Buckle-Up-Mag-Rig-Panel-Coyote-Brown-1152227952_1.webp", "VX Buckle Up Mag Rig Panel", 40.70m, 6 },
                    { new Guid("c0fe3f57-4d4a-427b-ad95-c5ea795549a8"), "Advanced active headset powered by a built-in battery.", "https://static5.gunfire.com/eng_pm_Tactical-HD-16-Bluetooth-Active-Headset-Olive-1152234035_1.webp", "Tactical HD-16 Bluetooth Active Headset", 123.50m, 3 },
                    { new Guid("c3e3661b-610b-401e-bbc3-b861954fc6d4"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", "CJP-02 Pro Combat Jacket", 149.50m, 7 },
                    { new Guid("dd2f87a1-5246-4b7e-b27e-2a92f64729a4"), "The ERM Headset is made out of durable plastic and metal. The ear pads and the headband padding have been equipped with covers to ensure high user comfort.", "https://static3.gunfire.com/eng_pm_Tactical-headset-ERM-Black-1152234028_1.webp", "Tactical headset ERM", 60.45m, 9 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("246a87a9-6996-45ec-9b18-e3cb7d5d8b62"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", "Dobuel Bell", "P226", 90m, 6, 2016 },
                    { new Guid("30ae4845-9dca-4c13-9e03-2122f285ce45"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("326bada2-2d00-4134-bcb4-5e9f30da9f18"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("3c9f51a9-aa6c-4920-a0f8-e902786e4bdc"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("5f050acd-acb9-4567-bc0d-1c9f55584f30"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("5ff8f5f3-a312-45c2-8dcd-708179a2b47c"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("60cbe3c8-b462-4772-97e1-30a36326568c"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("6792fc5d-c0c5-4d47-835a-57ec7c3d57de"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("7d2179ce-d198-4a73-a210-f37fc00ee43b"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static5.gunfire.com/eng_pm_SMC-9-Submachine-Gun-Replica-Black-1152226182_1.webp", "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("86951de2-06d3-45ff-99c6-09d7882c3fe1"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("a7f0eed2-c4aa-44e3-a4f1-4628c222e529"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("bbd23e2b-78db-424e-abdf-998c1ab2620f"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0cca6106-d2bc-40d6-8bbd-2ef74084eca4"), 1, "This noise reduction is like nothing else. Really helpful on the battlefield and won't bother you, because it is really light.", "https://static1.gunfire.com/eng_pm_JG-MP5SD-Silencer-part-069-1152217123_1.webp", "JG WORKS", "JG MP5SD Silencer", 18.50m, 6 },
                    { new Guid("42794277-9c69-4699-999a-8c2e9ae4cdda"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("59ee3f74-b505-4071-8741-b48eb0790c4c"), 1, "Theta Optics Red Dot 1x30 reflex sight is enclosed in a metal casing and powered by a CR2032 battery as well as allows to use a green or red dot during both day and night operations. The aimpoint can be smoothly regulated vertically and horizontally.", "https://static5.gunfire.com/eng_pm_Red-Dot-1x30-Reflex-Sight-Replica-Black-1152205530_1.webp", "THETA OPTICS", "Red Dot 1x30 Reflex Sight Replica", 26.50m, 4 },
                    { new Guid("65c6592d-08d9-4667-aac7-13d42693dbd0"), 1, "A forward grip made of aluminum compatible with handguards featuring the KEYMOD mounting system.", "https://static3.gunfire.com/eng_pm_Aluminum-KeyMod-Angled-Forward-Grip-Black-1152227182_1.webp", "METAL", "Aluminum KeyMod Angled Forward Grip", 15.60m, 5 },
                    { new Guid("871cfa20-8398-4b87-80ed-ae1af711c1ce"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("8b976634-c911-4046-b07b-a8e384637c71"), 1, "Complete aluminum Hop-Up chamber and a precision 6,03mm stainless steel barrel made in CNC technology.", "https://static2.gunfire.com/eng_pm_Complete-Hop-Up-Chamber-with-6-03mm-370mm-S-Barrel-for-VFC-BCM-MCMR-Replicas-1152232630_1.webp", "TNT", "Complete Hop-Up Chamber with 6.03mm 370mm S+Barrel", 130m, 4 },
                    { new Guid("bc726e85-3942-4eab-b84b-1bcb2cf8d538"), 1, "A light, adjustable stock made of polymer, compatible with any replica equipped with an AR15 buffer tube.", "https://static1.gunfire.com/eng_pm_HM0321-Lightweight-Polymer-Stock-for-M4-M16-Replicas-Tan-1152227562_1.webp", "DOUBLE BELL", "HM0321 Lightweight Polymer Stock", 21.50m, 8 },
                    { new Guid("ff7178e0-f91b-4a03-902f-c0b38f8daa5c"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("0c83291a-e1c7-4639-90b1-74d6560afaee"));

            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("0d376cfd-d367-4401-8f2b-b3367c098ef9"));

            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("5a4f16f5-5183-4dc6-939f-92258369f495"));

            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("63cc50ff-66c3-49d1-9e40-7ecd0dbafd08"));

            migrationBuilder.DeleteData(
                table: "Consumatives",
                keyColumn: "Id",
                keyValue: new Guid("9aa8283e-1014-485f-9e6b-2324cd204284"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("1938aaa9-aa2f-4f04-a6f8-e91a65b6ee26"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("1e7fee53-65d8-46ee-a075-ede3e1a2825a"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("5bb85faa-2c1e-4c8e-8faa-195d05f8fa91"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("6ac2fbb9-2d8f-49c5-8ae8-2bb39ad1e7d1"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("9f73713a-91c0-4913-b9f4-604cdd0f592b"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("c0fe3f57-4d4a-427b-ad95-c5ea795549a8"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("c3e3661b-610b-401e-bbc3-b861954fc6d4"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("dd2f87a1-5246-4b7e-b27e-2a92f64729a4"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("246a87a9-6996-45ec-9b18-e3cb7d5d8b62"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("30ae4845-9dca-4c13-9e03-2122f285ce45"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("326bada2-2d00-4134-bcb4-5e9f30da9f18"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("3c9f51a9-aa6c-4920-a0f8-e902786e4bdc"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5f050acd-acb9-4567-bc0d-1c9f55584f30"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("5ff8f5f3-a312-45c2-8dcd-708179a2b47c"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("60cbe3c8-b462-4772-97e1-30a36326568c"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("6792fc5d-c0c5-4d47-835a-57ec7c3d57de"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("7d2179ce-d198-4a73-a210-f37fc00ee43b"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("86951de2-06d3-45ff-99c6-09d7882c3fe1"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("a7f0eed2-c4aa-44e3-a4f1-4628c222e529"));

            migrationBuilder.DeleteData(
                table: "Guns",
                keyColumn: "Id",
                keyValue: new Guid("bbd23e2b-78db-424e-abdf-998c1ab2620f"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("0cca6106-d2bc-40d6-8bbd-2ef74084eca4"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("42794277-9c69-4699-999a-8c2e9ae4cdda"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("59ee3f74-b505-4071-8741-b48eb0790c4c"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("65c6592d-08d9-4667-aac7-13d42693dbd0"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("871cfa20-8398-4b87-80ed-ae1af711c1ce"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("8b976634-c911-4046-b07b-a8e384637c71"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("bc726e85-3942-4eab-b84b-1bcb2cf8d538"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("ff7178e0-f91b-4a03-902f-c0b38f8daa5c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "8c43d2b3-6b42-46d5-97c3-c4fae7026964");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d336d74-b03c-461d-8413-58d436fcc252", "AQAAAAEAACcQAAAAEI2nN1x1NLwOs1hZWu48ZWzCUrU6WCj2m/kDEw0EEM7uGgdc9wlz/6FLEzft5hNYLA==" });

            migrationBuilder.InsertData(
                table: "Consumatives",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("56491455-2840-4e5e-ac29-85e7867a4edc"), "For high precision and really good shots. These BBs are going to like you a lot! They are competition grade and are really balanced.", "https://m.media-amazon.com/images/I/51QY6Y7klQL._AC_UF1000,1000_QL80_.jpg", false, "BBs", 15.55m, 8 });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3a39ca4e-eea9-4740-a657-1ff5513a6e15"), "The light protective helmet LHO-01 is the first bulletproof high cut helmet produced by MASKPOL designed for the civilian market. It is designed to protect the wearer's head against direct shrapnel wounds and certain small arms projectiles.", "https://static4.gunfire.com/eng_pm_Ballistic-helmet-LHO-01-Olive-1152235163_1.webp", false, "Ballistic helmet LHO-01", 472.82m, 8 },
                    { new Guid("91f48e04-f322-4fea-a061-22240df3ad0e"), "Uniform clothing in the original and unique Multi-environmental Adaptive Pattern camouflage, intended for civilian and professional users who are interested in the military and actively spend their time outdoors - as well as in difficult and extreme conditions.", "https://static2.gunfire.com/eng_pm_CJP-02-Pro-Combat-Jacket-MAPA-R-1152234971_1.webp", false, "CJP-02 Pro Combat Jacket", 149.50m, 7 },
                    { new Guid("f59f1358-3afd-4bca-9b69-bdba346c1b03"), "The first aid kit can be attached using a Velcro panel to the equipment compatible with the MOLLE system or directly to the Velcro straps. The first aid kit also includes a tape with a buckle that will also help compress the contents of the pouch.", "https://static2.gunfire.com/eng_pm_Large-tear-off-first-aid-kit-Black-1152235193_1.webp", false, "Large tear - off first aid kit", 10.75m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Guns",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { new Guid("07ee7047-9f39-4e29-9e3e-29fa740fb812"), 4, "SMC-9 is a first construction of this type by G&G on the market. It is a combination of a submachine gun and a GTP9 pistol that came together into a unique construction. Thanks to its size, it is ideal for CQB games. Parts taken from GTP9 replica include the frame and the trigger mechanism - the barrel, chamber, cylinder set all belong to the conversion. Thanks to a special mechanism, the replica can fire in semi-auto as well as full-auto modes.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "G&G Armament", "SMC-9", 440.25m, 7, 2021 },
                    { new Guid("0ccf64bd-d775-462b-9867-c46e39833dc8"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. Attractive price in combination with an innovative spring exchange system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static5.gunfire.com/eng_pm_SA-C10-PDW-CORE-TM-Carbine-Replica-Black-1152225067_1.webp", false, "Specna Arms", "SA-C10 PDW CORE", 165.50m, 7, 2020 },
                    { new Guid("21b7d5d6-ab04-4477-8742-0ebffe72380c"), 5, "GF Custom Division is an idea conceived in the heads of the Gunfire airsoft team. We offer you the highest quality replicas, modified and configured by us, using only the best, tried and tested parts and accessories. Each element serves a specific purpose - these are exactly the configurations that we would like to use in the playing field ourselves. Many years of airsoft experience helps us in working on custom airsoft guns like this one, so we can safely say that GF Custom Division is a project created 100% by players for players.", "https://static2.gunfire.com/eng_pm_8871-Shotgun-Replica-Corpo-Wars-WGTO-1152234920_1.webp", false, "GF Custom Division", "8871", 260.57m, 5, 2020 },
                    { new Guid("260641db-e5fc-4ed7-b092-03171177f399"), 1, "Specna Arms meets the expectations of clients by presenting the CORE™ line of products - an exceptional series of replicas that introduces a new quality to the market. An attractive price in combination with an innovative spring change system as well as high-quality materials make this replica suitable for beginners and seasoned airsoft players alike.", "https://static2.gunfire.com/eng_pm_SA-C05-CORE-TM-Carbine-Replica-1152215724_1.webp", false, "Specna Arms", "SA-C05 CORE", 165.40m, 4, 2018 },
                    { new Guid("308ed68d-b8ae-44c3-b32b-22fe9026e897"), 1, "The EDGE 2.0 ™ series introduces a completely new quality to the Specna Arms replica family, adding new functionalities and innovations to the tried and tested design. As a result, Specna Arms EDGE 2.0 ™ carbines offer an exceptional high level of craftsmanship and technical advancement straight out of the box.", "https://static5.gunfire.com/eng_pm_SA-H22-EDGE-2-0-TM-Carbine-Replica-black-1152225956_1.webp", false, "Specna Arms", "SA-H22", 385.25m, 4, 2021 },
                    { new Guid("51736c52-b211-4e86-a29b-76e1cc4b3c2a"), 1, "The receiver, stock slide and an SF stock that holds the battery as well as the pistol grip were made of nylon fiber reinforced polymer. Remaining components such as the barrel, handguard, flash hider, enlarged charging handle and tactical sling swivels were made of metal (parts made of steel include the screws, pins, shell ejection window and mock bolt carrier). The receiver bears markings and a serial number.", "https://static4.gunfire.com/eng_pm_SA-C22-CORE-TM-Carbine-Replica-Chaos-Bronze-1152231391_1.webp", false, "Specna Arms", "SA-C22 CORE", 180.23m, 6, 2022 },
                    { new Guid("5768eb49-71fd-4d53-98a1-98c485100ca8"), 1, "Specna Arms proudly presents the FLEX line of replicas. An affordable price combined with an innovative quick spring change system, great performance straight out of the box and high-quality components makes this series an excellent choice for both beginners and experienced airsoft players alike.", "https://www.zerooneairsoft.com/products_image_15055_0.jpg", false, "Specna Arms", "SA-F02 FLEX HT", 250m, 3, 2021 },
                    { new Guid("6a29f6b6-9c83-4777-86d9-9b2fd8684a57"), 1, "The replica’s parts are very well aligned - in a way that could be thus far noticed solely in replicas by such top-tier manufacturers as G&P or Classic Army, the replica is also perfectly balanced. This allows for an almost ideal maneuverability of the replica and its weight is almost unnoticeable once the replica has been shouldered.", "https://static1.gunfire.com/eng_pm_SA-H11-ONE-TM-Carbine-Replica-Black-1152227616_1.webp", false, "Specna Arms", "SA-H11 ONE", 303.54m, 8, 2019 },
                    { new Guid("bde5cb59-7fb9-4cdb-b9c0-3b1345f5b19d"), 4, "A spring action replica of a sniper rifle. It is a bolt-action replica, which means that it has to be reloaded after each shot. The cradle with the stock were made from a durable polymer. Metal was used in the manufacture process of such elements as the barrel, trigger guard, bolt carrier, magwell and the charging handle.", "https://static3.gunfire.com/eng_pm_SW-04-Sniper-Rifle-Replica-with-Scope-and-Bipod-Olive-Drab-1152194766_1.webp", false, "Snow Wolf", "SW-04", 172.42m, 5, 2019 },
                    { new Guid("c18c1f4a-1cd6-4746-a940-9b9e50c892f0"), 6, "The grenade launcher replica is made of durable plastic and metal. The elements such as the barrel, the front iron aiming sights and the RIS rails are made of metal. The replica’s stock, the pistol grip, the body and the rear iron aiming sight are made of durable plastic.", "https://static2.gunfire.com/eng_pm_GL-06-grenade-launcher-1152195090_1.webp", false, "ASG", "GL-06", 205.56m, 4, 2016 },
                    { new Guid("e76b7699-77fc-454b-9f10-f004a025bb46"), 4, "This sniper rifle will win make you feel like a real soldier. With its silence and long range, you will be able to make really good shots and the enemies will wonder what had happened to them after.", "https://static2.gunfire.com/eng_pm_TAC-41-A-airsoft-sniper-rifle-Wolf-Grey-1152234909_1.webp", false, "Silverback Airsoft", "TAC-41 A", 710.50m, 3, 2022 },
                    { new Guid("f71a0c7b-1080-479c-bc6d-f123242b5b67"), 2, "Double Bell brand airsoft replica powered by green gas. The grip facings are made of plastic. The breech drop lever and decocker are made of steel. The skeleton, lock, external barrel and the rest of the components are made of aluminium and zinc alloy.", "https://static4.gunfire.com/eng_pm_P226-pistol-replica-778-Tan-1152235155_1.webp", false, "Dobuel Bell", "P226", 90m, 6, 2016 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2643cdf8-4f0d-476e-bf84-57462f75fca0"), 1, "A vertical forward grip made of metal intended for the attachment to KeyMod mounting system rails. Inside the mount is a small compartment for miscellaneous items. Features a rubber, anti-slip texture that improves the grip.", "https://static3.gunfire.com/eng_pm_KeyMod-Vertical-Grip-tan-1152221218_1.webp", false, "SHS", "KeyMod Vertical Grip", 23.65m, 5 },
                    { new Guid("9b25c046-de47-46d4-a0d5-f4d23f783c87"), 4, "Fess 1-8x is a durable most attractive price-wise driven hunt scope with a variable magnification in the Buckler family that does an exceptional job at satisfying the needs of hunters, dynamic sports shooters and tactical shooters.", "https://static2.gunfire.com/eng_pm_Fess-II-1-8x24-Driven-Hunt-Scope-1152224248_1.webp", false, "Buckler", "Fess II 1-8x24 Driven Hunt Scope", 260.05m, 3 },
                    { new Guid("b2c5520c-7b1b-438c-97f2-149213f9ffbc"), 1, "Shorter version of the angled front grip by PTS, made of a single piece of aluminum. Thanks to its compatibility with the M-LOK system, it can be mounted on any rail in this standard. Equipping the rifle with a front grip improves comfort and better control during fire.", "https://static4.gunfire.com/eng_pm_Fortis-Shift-TM-Short-Angle-Grip-Dark-Earth-1152230344_1.webp", false, "PTS", "Short Angle Grip", 50.50m, 3 }
                });
        }
    }
}
