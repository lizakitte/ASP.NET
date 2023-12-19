using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Manufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "car");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Organisations",
                newName: "OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "car",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ManufacturerEntity",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerEntity", x => x.ManufacturerId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e03a4b0-0e1e-4608-bf31-0a8aeb743f55", 0, "76eb0826-49b8-43de-b199-5ce858e28b10", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAENn9wtXYUibN7PIfLzLxEPUqMFP4Jwb+timqexzOWVUbypJfyRHcVZ/lt4/j32cxnw==", null, false, "5d38867a-53a5-4e3f-b2c0-0e5f8e2d4ab0", false, "adam" });

            migrationBuilder.InsertData(
                table: "ManufacturerEntity",
                columns: new[] { "ManufacturerId", "Name", "Address_City", "Address_Country", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 1001, "Ford", "Dearborn", "Unated States", "MI 48126", "Ford Motor Company" },
                    { 1002, "Honda", "Tokyo", "Japan", "107-8556", "2-1-1 Minami-Aoyama" }
                });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "OrganizationId",
                keyValue: 101,
                column: "Address_Country",
                value: "Polska");

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "OrganizationId",
                keyValue: 102,
                column: "Address_Country",
                value: "Polska");

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManufacturerId",
                value: 1001);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManufacturerId",
                value: 1002);

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 14, 20, 30, 53, 96, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 14, 20, 30, 53, 96, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 14, 20, 30, 53, 96, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "4e03a4b0-0e1e-4608-bf31-0a8aeb743f55" });

            migrationBuilder.CreateIndex(
                name: "IX_car_ManufacturerId",
                table: "car",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_car_ManufacturerEntity_ManufacturerId",
                table: "car",
                column: "ManufacturerId",
                principalTable: "ManufacturerEntity",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_ManufacturerEntity_ManufacturerId",
                table: "car");

            migrationBuilder.DropTable(
                name: "ManufacturerEntity");

            migrationBuilder.DropIndex(
                name: "IX_car_ManufacturerId",
                table: "car");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "4e03a4b0-0e1e-4608-bf31-0a8aeb743f55" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e03a4b0-0e1e-4608-bf31-0a8aeb743f55");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "car");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "Organisations",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "car",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efc341ce-392f-471f-a151-03f752d19046", "efc341ce-392f-471f-a151-03f752d19046", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ab1647a-330f-46e4-aba5-c28f30d62595", 0, "aba9fb94-1520-404a-83a0-a1c679105fb3", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPj+GyYLELG8zZUWmf7W1PdcfItZMCJDbt4hJkmi4vE+/japO146WpN2J0ifcQJUnA==", null, false, "b6380a52-42c9-429c-8203-b4143821739f", false, "adam" });

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 1,
                column: "Manufacturer",
                value: "Ford");

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 2,
                column: "Manufacturer",
                value: "Honda");

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
    }
}
