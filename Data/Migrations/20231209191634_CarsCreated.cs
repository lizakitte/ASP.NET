using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CarsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c876692c-bcc5-4f3b-859f-944ee6b98803", "4dba1b95-7cd3-405f-9b8d-3491fde49d96" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c876692c-bcc5-4f3b-859f-944ee6b98803");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4dba1b95-7cd3-405f-9b8d-3491fde49d96");

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<decimal>(type: "TEXT", nullable: true),
                    Power = table.Column<decimal>(type: "TEXT", nullable: true),
                    EngineType = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistratioinNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efc341ce-392f-471f-a151-03f752d19046", "efc341ce-392f-471f-a151-03f752d19046", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ab1647a-330f-46e4-aba5-c28f30d62595", 0, "aba9fb94-1520-404a-83a0-a1c679105fb3", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPj+GyYLELG8zZUWmf7W1PdcfItZMCJDbt4hJkmi4vE+/japO146WpN2J0ifcQJUnA==", null, false, "b6380a52-42c9-429c-8203-b4143821739f", false, "adam" });

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "Id", "Capacity", "EngineType", "Manufacturer", "Model", "Owner", "Power", "RegistratioinNumber" },
                values: new object[,]
                {
                    { 1, 4m, 3, "Ford", "Fusion", "Jan Nowak", 340m, 1362 },
                    { 2, 3.5m, 0, "Honda", "CR-V", "Kacper Malinowski", 190m, 98 }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 9, 20, 16, 34, 171, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 9, 20, 16, 34, 171, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 9, 20, 16, 34, 171, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "efc341ce-392f-471f-a151-03f752d19046", "3ab1647a-330f-46e4-aba5-c28f30d62595" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "efc341ce-392f-471f-a151-03f752d19046", "3ab1647a-330f-46e4-aba5-c28f30d62595" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc341ce-392f-471f-a151-03f752d19046");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ab1647a-330f-46e4-aba5-c28f30d62595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c876692c-bcc5-4f3b-859f-944ee6b98803", "c876692c-bcc5-4f3b-859f-944ee6b98803", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4dba1b95-7cd3-405f-9b8d-3491fde49d96", 0, "82025c9b-4d90-4c6c-9973-4e5b18880902", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEBf5Ynuv+/WQKKm0Yo2W+PmDa79AvCOjJqp+b1U6LdBQBfiSUsbDbPB5xJSwbk6Miw==", null, false, "3818edfd-57a7-4726-b0f2-da4bf1b5b3cd", false, "adam" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 11, 22, 11, 42, 2, 211, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 11, 22, 11, 42, 2, 211, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 11, 22, 11, 42, 2, 211, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c876692c-bcc5-4f3b-859f-944ee6b98803", "4dba1b95-7cd3-405f-9b8d-3491fde49d96" });
        }
    }
}
