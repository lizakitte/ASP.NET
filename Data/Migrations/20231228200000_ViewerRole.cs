using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ViewerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9", "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9", "User", "USER" },
                    { "ebb32830-fe02-4dc7-8fc9-45e84886aa41", "ebb32830-fe02-4dc7-8fc9-45e84886aa41", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03b9d487-5008-4933-a504-5df09696f095", 0, "ea283fe4-b91f-4f35-978e-239bc445e9c4", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAEAACcQAAAAEJd765Q+Ah24TJLjSIsy6lU7aGl2qQiG1aI95ago7Jg3vWahwLyOyaEZx4Fb3UXXwQ==", null, false, "106e6ebd-690c-4093-b4a4-dabdabec1e87", false, "user" },
                    { "baa447d2-63d2-46e3-8495-2940fb54a2b4", 0, "75831d10-fd60-48f8-9d90-7e299986f85c", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPbKhBOqKW1p2WL8tyXT4TGENXuVRyhK+zVopsavYXg3LNQJwPJtN3GxLPemAN7+zg==", null, false, "d5ac1a0d-1d05-4d3d-807f-a813920a3a17", false, "adam" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 28, 21, 0, 0, 117, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9", "03b9d487-5008-4933-a504-5df09696f095" },
                    { "ebb32830-fe02-4dc7-8fc9-45e84886aa41", "baa447d2-63d2-46e3-8495-2940fb54a2b4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9", "03b9d487-5008-4933-a504-5df09696f095" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebb32830-fe02-4dc7-8fc9-45e84886aa41", "baa447d2-63d2-46e3-8495-2940fb54a2b4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd3fe4d1-f5ea-4db4-b06c-b82ac85ad5b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb32830-fe02-4dc7-8fc9-45e84886aa41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03b9d487-5008-4933-a504-5df09696f095");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "baa447d2-63d2-46e3-8495-2940fb54a2b4");

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
    }
}
