using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Manufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_ManufacturerEntity_ManufacturerId",
                table: "car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufacturerEntity",
                table: "ManufacturerEntity");

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

            migrationBuilder.RenameTable(
                name: "ManufacturerEntity",
                newName: "Manufacturers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "ManufacturerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6afdda6-db67-4787-a43f-2d7a7811c063", 0, "83c16a29-b603-4c5d-8744-f804d861d6f9", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEIDFYykPD/Ta/tqy3OCvEJcvELd71ifal7Wv2P9KMv60iciGdBhAcl+NJZzAh4aKtg==", null, false, "57dbd725-1581-49ee-a5e5-bc491ad82f55", false, "adam" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 12, 19, 14, 53, 6, 597, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 12, 19, 14, 53, 6, 597, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 12, 19, 14, 53, 6, 597, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "f6afdda6-db67-4787-a43f-2d7a7811c063" });

            migrationBuilder.AddForeignKey(
                name: "FK_car_Manufacturers_ManufacturerId",
                table: "car",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_Manufacturers_ManufacturerId",
                table: "car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "f6afdda6-db67-4787-a43f-2d7a7811c063" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57f5cfc2-48ea-4b52-859b-fbc2b6054319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6afdda6-db67-4787-a43f-2d7a7811c063");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "ManufacturerEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufacturerEntity",
                table: "ManufacturerEntity",
                column: "ManufacturerId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "9f6f760b-d4e8-4a0f-9a58-3eb0617e26a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e03a4b0-0e1e-4608-bf31-0a8aeb743f55", 0, "76eb0826-49b8-43de-b199-5ce858e28b10", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAENn9wtXYUibN7PIfLzLxEPUqMFP4Jwb+timqexzOWVUbypJfyRHcVZ/lt4/j32cxnw==", null, false, "5d38867a-53a5-4e3f-b2c0-0e5f8e2d4ab0", false, "adam" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_car_ManufacturerEntity_ManufacturerId",
                table: "car",
                column: "ManufacturerId",
                principalTable: "ManufacturerEntity",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
