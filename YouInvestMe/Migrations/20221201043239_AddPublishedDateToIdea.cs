using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddPublishedDateToIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PublishedDate",
                table: "Idea",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4aa6d075-9588-4282-b344-2df3a638d3c5", null, "Creator", "CREATOR" },
                    { "b3e01535-19b5-43ae-bf16-25884b6cdf0c", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aa6d075-9588-4282-b344-2df3a638d3c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e01535-19b5-43ae-bf16-25884b6cdf0c");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
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
    }
}
