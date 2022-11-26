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
                keyValue: "43600804-28db-4143-a67b-a37ec478a661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe85216c-b30f-4b65-82a6-e0e23304c4c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5616220b-8ba3-4a6e-8a3c-aec403c54462", null, "Creator", "CREATOR" },
                    { "bdff7283-cc49-4745-a561-b9914c9c2165", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5616220b-8ba3-4a6e-8a3c-aec403c54462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdff7283-cc49-4745-a561-b9914c9c2165");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43600804-28db-4143-a67b-a37ec478a661", null, "Creator", "CREATOR" },
                    { "fe85216c-b30f-4b65-82a6-e0e23304c4c7", null, "Manager", "MANAGER" }
                });
        }
    }
}
