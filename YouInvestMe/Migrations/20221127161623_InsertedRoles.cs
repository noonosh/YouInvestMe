using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class InsertedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d92f4c77-bb0a-4900-9169-cca97eb35694");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc292014-8a4b-4e04-ba43-a25ca873ecee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05f0267f-bd25-4a5d-abae-f83196e83d92", null, "Creator", "CREATOR" },
                    { "f06e937e-c947-4a6d-9eae-f51fcf0800ff", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05f0267f-bd25-4a5d-abae-f83196e83d92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f06e937e-c947-4a6d-9eae-f51fcf0800ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d92f4c77-bb0a-4900-9169-cca97eb35694", null, "Creator", "CREATOR" },
                    { "fc292014-8a4b-4e04-ba43-a25ca873ecee", null, "Manager", "MANAGER" }
                });
        }
    }
}
