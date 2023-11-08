using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "ContactId", "Birth", "Email", "name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4409), "adam@wsei.edu.pl", "Adam", "123456789" },
                    { 2, new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4456), "ewa@wsei.edu.pl", "Ewa", "123456777" },
                    { 3, new DateTime(2023, 11, 8, 11, 43, 56, 389, DateTimeKind.Local).AddTicks(4460), "karol@wsei.edu.pl", "Karol", "123456788" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
