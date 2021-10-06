using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRestaurant.DAL.Migrations
{
    public partial class OrderSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(4405), new DateTime(2021, 10, 9, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 5, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5166), new DateTime(2021, 10, 7, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 5, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5180), new DateTime(2021, 10, 6, 19, 49, 57, 394, DateTimeKind.Local).AddTicks(5182) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5195), new DateTime(2021, 10, 3, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5200), new DateTime(2021, 10, 8, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5205), new DateTime(2021, 10, 7, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedAt", "PreferredDeliveryDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 22, new DateTime(2020, 9, 23, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5282), new DateTime(2021, 9, 21, 4, 49, 57, 394, DateTimeKind.Local).AddTicks(5284), 3, "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 21, new DateTime(2021, 10, 5, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5277), new DateTime(2021, 10, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5279), 0, "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 20, new DateTime(2019, 11, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5272), new DateTime(2021, 9, 7, 12, 49, 57, 394, DateTimeKind.Local).AddTicks(5274), 4, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 19, new DateTime(2020, 9, 4, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5267), new DateTime(2020, 9, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5269), 4, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 18, new DateTime(2020, 9, 9, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5262), new DateTime(2020, 9, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5264), 4, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 17, new DateTime(2020, 9, 16, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5257), new DateTime(2020, 9, 20, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5260), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 15, new DateTime(2021, 7, 29, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 7, 31, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5250), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 14, new DateTime(2021, 8, 3, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5243), new DateTime(2021, 10, 4, 3, 49, 57, 394, DateTimeKind.Local).AddTicks(5245), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 13, new DateTime(2021, 8, 7, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5238), new DateTime(2021, 8, 8, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5241), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 12, new DateTime(2021, 8, 12, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5234), new DateTime(2021, 8, 15, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5236), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 11, new DateTime(2021, 8, 17, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5229), new DateTime(2021, 8, 22, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5231), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 10, new DateTime(2021, 8, 24, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5224), new DateTime(2021, 8, 26, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5226), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 9, new DateTime(2021, 8, 27, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5219), new DateTime(2021, 10, 5, 2, 49, 57, 394, DateTimeKind.Local).AddTicks(5221), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 8, new DateTime(2021, 9, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5214), new DateTime(2021, 9, 3, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5217), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 16, new DateTime(2020, 9, 27, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5253), new DateTime(2020, 10, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5255), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 7, new DateTime(2021, 9, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5209), new DateTime(2021, 9, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5212), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" }
                });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 7, 16, 49, 57, 390, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 17, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 26, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 7, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 27, 16, 49, 57, 393, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "OrderId", "RestaurantName", "UserFullName", "RestaurantAddress_City", "RestaurantAddress_PhoneNumber", "RestaurantAddress_Street", "RestaurantAddress_ZipCode", "UserAddress_City", "UserAddress_PhoneNumber", "UserAddress_Street", "UserAddress_ZipCode" },
                values: new object[,]
                {
                    { 7, 7, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 19, 19, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 16, 16, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 11, 11, "Princess Bakery&Bistro Örs vezér tér", "Carson Alexander", "Budapest", "06305412567", "Örs vezér tere 1", 1148, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 18, 18, "Twentysix Budapest", "Carson Alexander", "Budapest", "06301233456", "Király utca 26", 1011, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 13, 13, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 20, 20, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 10, 10, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 17, 17, "Princess Bakery&Bistro Örs vezér tér", "Carson Alexander", "Budapest", "06305412567", "Örs vezér tere 1", 1148, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 9, 9, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 12, 12, "Twentysix Budapest", "Carson Alexander", "Budapest", "06301233456", "Király utca 26", 1011, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 14, 14, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 8, 8, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 22, 22, "Trófea Grill Étterem - Király", "Bács Imre", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06301451567", "Petőfi utca 3", 1017 },
                    { 15, 15, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 21, 21, "Trófea Grill Étterem - Király", "Bács Imre", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06301451567", "Petőfi utca 3", 1017 }
                });

            migrationBuilder.InsertData(
                table: "OrderFood",
                columns: new[] { "Id", "Amount", "FoodId", "OrderId", "Price" },
                values: new object[,]
                {
                    { 70, 2, 16, 18, 4950 },
                    { 66, 4, 10, 17, 2390 },
                    { 67, 2, 11, 17, 2190 },
                    { 64, 3, 4, 16, 900 },
                    { 63, 1, 3, 16, 3700 },
                    { 68, 2, 12, 17, 2190 },
                    { 62, 2, 6, 16, 1250 },
                    { 61, 1, 7, 16, 1400 },
                    { 69, 2, 15, 18, 3550 },
                    { 65, 6, 9, 17, 2490 },
                    { 73, 1, 5, 19, 1090 },
                    { 72, 2, 18, 18, 7650 },
                    { 74, 1, 6, 19, 1250 },
                    { 75, 1, 3, 19, 3700 },
                    { 76, 1, 4, 19, 900 },
                    { 77, 3, 7, 20, 1400 },
                    { 78, 3, 6, 20, 1250 },
                    { 79, 3, 3, 20, 3700 },
                    { 80, 3, 4, 20, 900 },
                    { 81, 2, 5, 21, 1090 },
                    { 82, 4, 6, 21, 1250 },
                    { 83, 4, 3, 21, 3700 },
                    { 84, 4, 4, 21, 900 },
                    { 85, 1, 7, 22, 1400 },
                    { 86, 2, 6, 22, 1250 },
                    { 71, 2, 17, 18, 2950 }
                });

            migrationBuilder.InsertData(
                table: "OrderFood",
                columns: new[] { "Id", "Amount", "FoodId", "OrderId", "Price" },
                values: new object[,]
                {
                    { 60, 2, 4, 15, 900 },
                    { 56, 1, 8, 14, 1250 },
                    { 58, 2, 6, 15, 1250 },
                    { 38, 2, 6, 10, 1250 },
                    { 37, 4, 7, 10, 1400 },
                    { 36, 1, 4, 9, 900 },
                    { 35, 2, 3, 9, 3700 },
                    { 34, 1, 6, 9, 1250 },
                    { 33, 2, 5, 9, 1090 },
                    { 39, 4, 3, 10, 3700 },
                    { 32, 1, 8, 8, 1250 },
                    { 30, 1, 2, 8, 3650 },
                    { 29, 1, 1, 8, 4750 },
                    { 28, 1, 5, 7, 1090 },
                    { 27, 1, 4, 7, 900 },
                    { 26, 2, 3, 7, 3700 },
                    { 25, 3, 1, 7, 4750 },
                    { 31, 2, 3, 8, 3700 },
                    { 40, 3, 4, 10, 900 },
                    { 41, 1, 9, 11, 2490 },
                    { 42, 1, 10, 11, 2390 },
                    { 57, 2, 5, 15, 1090 },
                    { 87, 1, 3, 22, 3700 },
                    { 55, 2, 3, 14, 3700 },
                    { 54, 5, 2, 14, 3650 },
                    { 53, 1, 1, 14, 4750 },
                    { 52, 2, 5, 13, 1090 },
                    { 51, 1, 4, 13, 900 },
                    { 50, 4, 3, 13, 3700 },
                    { 49, 5, 1, 13, 4750 },
                    { 48, 1, 18, 12, 7650 },
                    { 47, 1, 17, 12, 2950 },
                    { 46, 3, 16, 12, 4950 },
                    { 45, 1, 15, 12, 3550 },
                    { 44, 1, 12, 11, 2190 },
                    { 43, 1, 11, 11, 2190 },
                    { 59, 2, 3, 15, 3700 },
                    { 88, 2, 4, 22, 900 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(8998), new DateTime(2021, 10, 1, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 27, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9824), new DateTime(2021, 9, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 27, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9837), new DateTime(2021, 9, 28, 20, 19, 53, 15, DateTimeKind.Local).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9853), new DateTime(2021, 9, 25, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9858), new DateTime(2021, 9, 30, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9861) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9863), new DateTime(2021, 9, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 30, 17, 19, 53, 12, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 9, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 18, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 30, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 19, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3337));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 19, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3340));
        }
    }
}
