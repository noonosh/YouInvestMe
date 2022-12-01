using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDateCreatedFromIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f20d440-869c-4266-a5ca-8e6faf0360fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6493fd0-4e92-49f9-b1b1-50b431183680");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Idea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb350805-da39-4680-a1a1-bb47f5572dcd", null, "Manager", "MANAGER" },
                    { "f1163353-3d12-4e04-9637-6faa28e690c8", null, "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb350805-da39-4680-a1a1-bb47f5572dcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1163353-3d12-4e04-9637-6faa28e690c8");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Idea",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f20d440-869c-4266-a5ca-8e6faf0360fd", null, "Manager", "MANAGER" },
                    { "f6493fd0-4e92-49f9-b1b1-50b431183680", null, "Creator", "CREATOR" }
                });
        }
    }
}
