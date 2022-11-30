using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b9f5ff9-67a3-4bdd-b96e-b3bd8bf54114");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf47f106-7f81-4c0f-9197-cbf600f38229");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7b9f5ff9-67a3-4bdd-b96e-b3bd8bf54114", null, "Manager", "MANAGER" },
                    { "cf47f106-7f81-4c0f-9197-cbf600f38229", null, "Creator", "CREATOR" }
                });
        }
    }
}
