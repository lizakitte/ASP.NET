using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactCarsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "car");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "car",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4652c287-3ce6-4cd3-b652-aa8011c0814d", "4652c287-3ce6-4cd3-b652-aa8011c0814d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3cbffc7c-40ba-4b07-8cde-d49a89e0c072", 0, "f5f2fb87-ecef-48d5-8466-e1a6ac25257e", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEISBxWXcj5JVwqB5KsTMCYgmTjh4wkcRDqupoXxIZ6v/p/JbetSU9z47ZMNb3O6F1Q==", null, false, "0a21bd71-0d67-4df0-991f-66a444f55352", false, "adam" });

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContactId",
                value: 2);

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

            migrationBuilder.CreateIndex(
                name: "IX_car_ContactId",
                table: "car",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_car_contacts_ContactId",
                table: "car",
                column: "ContactId",
                principalTable: "contacts",
                principalColumn: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_contacts_ContactId",
                table: "car");

            migrationBuilder.DropIndex(
                name: "IX_car_ContactId",
                table: "car");

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

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "car");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "car",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "57f5cfc2-48ea-4b52-859b-fbc2b6054319", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6afdda6-db67-4787-a43f-2d7a7811c063", 0, "83c16a29-b603-4c5d-8744-f804d861d6f9", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEIDFYykPD/Ta/tqy3OCvEJcvELd71ifal7Wv2P9KMv60iciGdBhAcl+NJZzAh4aKtg==", null, false, "57dbd725-1581-49ee-a5e5-bc491ad82f55", false, "adam" });

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 1,
                column: "Owner",
                value: "Jan Nowak");

            migrationBuilder.UpdateData(
                table: "car",
                keyColumn: "Id",
                keyValue: 2,
                column: "Owner",
                value: "Kacper Malinowski");

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
        }
    }
}
