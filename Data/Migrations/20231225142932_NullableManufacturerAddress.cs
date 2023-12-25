using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableManufacturerAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4652c287-3ce6-4cd3-b652-aa8011c0814d", "3cbffc7c-40ba-4b07-8cde-d49a89e0c072" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4652c287-3ce6-4cd3-b652-aa8011c0814d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbffc7c-40ba-4b07-8cde-d49a89e0c072");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f24af637-5246-4a71-a73d-166a115922bc", "f24af637-5246-4a71-a73d-166a115922bc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4a0d31e7-76ca-4541-95d6-7f87047dfc0c", 0, "453bea70-06ba-46b7-b436-93d93575bd38", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAECzJeQxu3BgHhLkgaS5Anl/2l7jQ+LXX5u0DlKQiTFr0rvU1PV3kt0AHcTEv0dlKbg==", null, false, "9ca5382c-faf0-4c78-8f42-798c00574a5e", false, "adam" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 25, 15, 29, 32, 428, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 25, 15, 29, 32, 428, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 25, 15, 29, 32, 428, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f24af637-5246-4a71-a73d-166a115922bc", "4a0d31e7-76ca-4541-95d6-7f87047dfc0c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f24af637-5246-4a71-a73d-166a115922bc", "4a0d31e7-76ca-4541-95d6-7f87047dfc0c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f24af637-5246-4a71-a73d-166a115922bc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a0d31e7-76ca-4541-95d6-7f87047dfc0c");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_PostalCode",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4652c287-3ce6-4cd3-b652-aa8011c0814d", "4652c287-3ce6-4cd3-b652-aa8011c0814d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cbffc7c-40ba-4b07-8cde-d49a89e0c072", 0, "f5f2fb87-ecef-48d5-8466-e1a6ac25257e", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEISBxWXcj5JVwqB5KsTMCYgmTjh4wkcRDqupoXxIZ6v/p/JbetSU9z47ZMNb3O6F1Q==", null, false, "0a21bd71-0d67-4df0-991f-66a444f55352", false, "adam" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 20, 18, 1, 4, 167, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 20, 18, 1, 4, 167, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 20, 18, 1, 4, 167, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4652c287-3ce6-4cd3-b652-aa8011c0814d", "3cbffc7c-40ba-4b07-8cde-d49a89e0c072" });
        }
    }
}
