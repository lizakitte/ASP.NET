using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Organisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "Description", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 101, "Uczelnia wyższa", "WSEI", "Kraków", "31-150", "św. Filipa 17" },
                    { 102, "Przedsiębiorstwo IT", "Comarch", "Kraków", "36-160", "Rozwoju 1/4" }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                columns: new[] { "Birth", "OrganizationId" },
                values: new object[] { new DateTime(2023, 11, 15, 11, 27, 8, 906, DateTimeKind.Local).AddTicks(3674), 101 });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                columns: new[] { "Birth", "OrganizationId" },
                values: new object[] { new DateTime(2023, 11, 15, 11, 27, 8, 906, DateTimeKind.Local).AddTicks(3718), 102 });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                columns: new[] { "Birth", "OrganizationId" },
                values: new object[] { new DateTime(2023, 11, 15, 11, 27, 8, 906, DateTimeKind.Local).AddTicks(3722), null });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Organisations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "Organisations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Organisations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "Birth",
                value: new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "Birth",
                value: new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "Birth",
                value: new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4460));
        }
    }
}
