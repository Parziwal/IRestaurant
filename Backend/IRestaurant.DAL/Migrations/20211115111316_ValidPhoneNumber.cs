using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRestaurant.DAL.Migrations
{
    public partial class ValidPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FavouriteRestaurant",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 2, 2, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 3, 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 4, 4, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 5, 5, "475c5e32-049c-4d7b-a963-02ebdc15a94b" }
                });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-541-2567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-3456", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-541-2567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-3456", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-541-2567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-3456", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-20-121-4561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-30-145-1567" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06-30-123-4567", "06-30-145-1567" });

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
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address_PhoneNumber",
                value: "06-30-123-4567");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address_PhoneNumber",
                value: "06-30-541-2567");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address_PhoneNumber",
                value: "06-30-123-3456");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address_PhoneNumber",
                value: "06-20-343-3499");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address_PhoneNumber",
                value: "06-20-293-3472");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address_PhoneNumber",
                value: "06-30-193-3174");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 7,
                column: "Address_PhoneNumber",
                value: "06-20-194-4175");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 8,
                column: "Address_PhoneNumber",
                value: "06-30-293-2179");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 9,
                column: "Address_PhoneNumber",
                value: "06-20-493-3175");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 10,
                column: "Address_PhoneNumber",
                value: "06-20-173-3274");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 11,
                column: "Address_PhoneNumber",
                value: "06-20-336-9867");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 12,
                column: "Address_PhoneNumber",
                value: "06-30-187-6756");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 13,
                column: "Address_PhoneNumber",
                value: "06-20-997-7645");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 14,
                column: "Address_PhoneNumber",
                value: "06-20-997-2364");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 15,
                column: "Address_PhoneNumber",
                value: "06-30-778-9631");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 16,
                column: "Address_PhoneNumber",
                value: "06-20-876-5698");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 17,
                column: "Address_PhoneNumber",
                value: "06-20-876-1985");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 18,
                column: "Address_PhoneNumber",
                value: "06-20-587-2956");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 19,
                column: "Address_PhoneNumber",
                value: "06-30-817-3984");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 20,
                column: "Address_PhoneNumber",
                value: "06-20-813-3946");

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 12, 13, 13, 857, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6605));

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
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 5, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6801));

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
                column: "CreatedAt",
                value: new DateTime(2021, 9, 16, 12, 13, 13, 864, DateTimeKind.Local).AddTicks(6837));

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

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address_PhoneNumber",
                value: "06-20-121-4561");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address_PhoneNumber",
                value: "06-30-145-1567");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address_PhoneNumber",
                value: "06-30-145-5892");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address_PhoneNumber",
                value: "06-20-135-1961");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address_PhoneNumber",
                value: "06-30-145-1861");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavouriteRestaurant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavouriteRestaurant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavouriteRestaurant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavouriteRestaurant",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FavouriteRestaurant",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06305412567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301233456", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06305412567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301233456", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06305412567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301233456", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06201214561" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06301451567" });

            migrationBuilder.UpdateData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "RestaurantAddress_PhoneNumber", "UserAddress_PhoneNumber" },
                values: new object[] { "06301234567", "06301451567" });

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

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5209), new DateTime(2021, 9, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 9, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5214), new DateTime(2021, 9, 3, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 27, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5219), new DateTime(2021, 10, 5, 2, 49, 57, 394, DateTimeKind.Local).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 24, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5224), new DateTime(2021, 8, 26, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 17, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5229), new DateTime(2021, 8, 22, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 12, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5234), new DateTime(2021, 8, 15, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 7, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5238), new DateTime(2021, 8, 8, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 8, 3, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5243), new DateTime(2021, 10, 4, 3, 49, 57, 394, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 7, 29, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 7, 31, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 9, 27, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5253), new DateTime(2020, 10, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 9, 16, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5257), new DateTime(2020, 9, 20, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 9, 9, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5262), new DateTime(2020, 9, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 9, 4, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5267), new DateTime(2020, 9, 6, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2019, 11, 1, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5272), new DateTime(2021, 9, 7, 12, 49, 57, 394, DateTimeKind.Local).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2021, 10, 5, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5277), new DateTime(2021, 10, 11, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "PreferredDeliveryDate" },
                values: new object[] { new DateTime(2020, 9, 23, 16, 49, 57, 394, DateTimeKind.Local).AddTicks(5282), new DateTime(2021, 9, 21, 4, 49, 57, 394, DateTimeKind.Local).AddTicks(5284) });

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address_PhoneNumber",
                value: "06301234567");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address_PhoneNumber",
                value: "06305412567");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address_PhoneNumber",
                value: "06301233456");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address_PhoneNumber",
                value: "06203433499");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address_PhoneNumber",
                value: "06202933472");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address_PhoneNumber",
                value: "06301933174");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 7,
                column: "Address_PhoneNumber",
                value: "06201944175");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 8,
                column: "Address_PhoneNumber",
                value: "06302932179");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 9,
                column: "Address_PhoneNumber",
                value: "06204933175");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 10,
                column: "Address_PhoneNumber",
                value: "06201733274");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 11,
                column: "Address_PhoneNumber",
                value: "06203369867");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 12,
                column: "Address_PhoneNumber",
                value: "06301876756");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 13,
                column: "Address_PhoneNumber",
                value: "06209977645");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 14,
                column: "Address_PhoneNumber",
                value: "06209972364");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 15,
                column: "Address_PhoneNumber",
                value: "06307789631");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 16,
                column: "Address_PhoneNumber",
                value: "06208765698");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 17,
                column: "Address_PhoneNumber",
                value: "06208761985");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 18,
                column: "Address_PhoneNumber",
                value: "06205872956");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 19,
                column: "Address_PhoneNumber",
                value: "06308173984");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 20,
                column: "Address_PhoneNumber",
                value: "06208133946");

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

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address_PhoneNumber",
                value: "06201214561");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address_PhoneNumber",
                value: "06301451567");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address_PhoneNumber",
                value: "06301455892");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address_PhoneNumber",
                value: "06201351961");

            migrationBuilder.UpdateData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address_PhoneNumber",
                value: "06301451861");
        }
    }
}
