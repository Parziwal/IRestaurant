using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRestaurant.DAL.Migrations
{
    public partial class EditReviewsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 26, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(1539), new DateTime(2021, 11, 29, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(3682) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 25, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4659), new DateTime(2021, 11, 27, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4699) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 25, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4711), new DateTime(2021, 11, 26, 22, 42, 11, 162, DateTimeKind.Local).AddTicks(4719) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 21, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4767), new DateTime(2021, 11, 23, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 26, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4783), new DateTime(2021, 11, 28, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 26, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 11, 27, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4808) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4817), new DateTime(2021, 11, 1, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 22, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4833), new DateTime(2021, 10, 24, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 17, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4849), new DateTime(2021, 11, 25, 5, 42, 11, 162, DateTimeKind.Local).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 14, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4865), new DateTime(2021, 10, 16, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 7, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4880), new DateTime(2021, 10, 12, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 2, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4896), new DateTime(2021, 10, 5, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4903) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 27, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4912), new DateTime(2021, 9, 28, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4919) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 23, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4927), new DateTime(2021, 11, 24, 6, 42, 11, 162, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 18, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4943), new DateTime(2021, 9, 20, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 11, 17, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4958), new DateTime(2020, 11, 21, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4967) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 11, 6, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4975), new DateTime(2020, 11, 10, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 10, 30, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4991), new DateTime(2020, 11, 1, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 10, 25, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5006), new DateTime(2020, 10, 27, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5014) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2019, 12, 22, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5022), new DateTime(2021, 10, 28, 15, 42, 11, 162, DateTimeKind.Local).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 25, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5038), new DateTime(2021, 12, 1, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 11, 13, 19, 42, 11, 162, DateTimeKind.Local).AddTicks(5054), new DateTime(2021, 11, 11, 7, 42, 11, 162, DateTimeKind.Local).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 9, 27, 19, 42, 11, 98, DateTimeKind.Local).AddTicks(7251), "Ízletes fogások, kiváló kiszállítás." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7641), "A Rib-eye steakel nagyon meg voltam elégedve, de a futárok egy kicsit túl voltak terhelve és a rendelést csak késve tudtam átvenni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7786), "A Rib-eye steakel nagyon meg voltam elégedve, de a futárok egy kicsit túl voltak terhelve és a rendelést csak késve tudtam átvenni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2021, 10, 7, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7797), "Itt az étel nem kizárólag étel, sokkal inkább egy különleges utazás. A kiszállítás másodpercre pontosan kiszámolt, mérnöki pontosságú.", "Több mint étel" });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7807), "A Rib-eye steakel nagyon meg voltam elégedve, de a futárok egy kicsit túl voltak terhelve és a rendelést csak késve tudtam átvenni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7819), "Összességében azt mondhatom, igazán remek, kiváló ár-érték arányú ebédet hoztak össze. Szívesen rendelek még tőlük." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7828), "A Rib-eye steakel nagyon meg voltam elégedve, de a futárok egy kicsit túl voltak terhelve és a rendelést csak késve tudtam átvenni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7838), "Összességében azt mondhatom, igazán remek, kiváló ár-érték arányú ebédet hoztak össze. Szívesen rendelek még tőlük." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7848), "Összességében azt mondhatom, igazán remek, kiváló ár-érték arányú ebédet hoztak össze. Szívesen rendelek még tőlük." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7857), "Összességében azt mondhatom, igazán remek, kiváló ár-érték arányú ebédet hoztak össze. Szívesen rendelek még tőlük." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7867), "Összességében azt mondhatom, igazán remek, kiváló ár-érték arányú ebédet hoztak össze. Szívesen rendelek még tőlük." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 16, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7879), "A rendelésem csak több óra késéssel érkezett meg és elárulom nem érte meg a várakozást. A futár nagyon lekezelő és ápolatlan volt. Senkinek nem ajánlom a helyet." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7889), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Ha rendelsz tőlük nem fogsz csalódni, remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7900), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Ha rendelsz tőlük nem fogsz csalódni, remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7911), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Ha rendelsz tőlük nem fogsz csalódni, remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7921), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Ha rendelsz tőlük nem fogsz csalódni, remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 6, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 9, 27, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(8014), "A rendelésem csak több óra késéssel érkezett meg és elárulom nem érte meg a várakozást. A futár nagyon lekezelő és ápolatlan volt. Senkinek nem ajánlom a helyet." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 19, 42, 11, 157, DateTimeKind.Local).AddTicks(8033));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(2717), new DateTime(2021, 11, 18, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6707), new DateTime(2021, 11, 16, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6744), new DateTime(2021, 11, 15, 15, 13, 13, 869, DateTimeKind.Local).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 10, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6794), new DateTime(2021, 11, 12, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6807), new DateTime(2021, 11, 17, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 15, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6820), new DateTime(2021, 11, 16, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 16, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6832), new DateTime(2021, 10, 21, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 11, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6845), new DateTime(2021, 10, 13, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 6, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6858), new DateTime(2021, 11, 13, 22, 13, 13, 869, DateTimeKind.Local).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 3, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6870), new DateTime(2021, 10, 5, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6883), new DateTime(2021, 10, 1, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 21, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6895), new DateTime(2021, 9, 24, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 16, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6908), new DateTime(2021, 9, 17, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 12, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6921), new DateTime(2021, 11, 12, 23, 13, 13, 869, DateTimeKind.Local).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 7, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6934), new DateTime(2021, 9, 9, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6939) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 11, 6, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6946), new DateTime(2020, 11, 10, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6951) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 10, 26, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6958), new DateTime(2020, 10, 30, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 10, 19, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6970), new DateTime(2020, 10, 21, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6975) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 10, 14, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6982), new DateTime(2020, 10, 16, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2019, 12, 11, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 10, 17, 8, 13, 13, 869, DateTimeKind.Local).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(7006), new DateTime(2021, 11, 20, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(7012) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 11, 2, 12, 13, 13, 869, DateTimeKind.Local).AddTicks(7018), new DateTime(2021, 10, 31, 0, 13, 13, 869, DateTimeKind.Local).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 9, 16, 12, 13, 13, 857, DateTimeKind.Local).AddTicks(8686), "Ízletes fogások, kiváló kiszolgálás." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6605), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6702), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2021, 9, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6710), "Itt az étkezés nem kizárólag étkezés, sokkal inkább egy különleges szertartás. A kiszolgálás másodpercre pontosan kiszámolt, mérnöki pontosságú.", "Több mint étkezés" });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6717), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6725), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6732), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6740), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6749), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6756), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6764), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 11, 5, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6771), "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6779), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6786), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6794), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6801), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ." });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2021, 9, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6837), "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet. " });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6851));
        }
    }
}
