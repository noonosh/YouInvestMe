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
                keyValue: "199d67b6-783f-4b25-90c5-2e292b38a385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff267017-d2ec-4cb6-b2a0-d94668bb06be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "510e7980-1bfa-46dc-a74f-f52804ccd545", null, "Creator", "CREATOR" },
                    { "f950daf2-d7b9-4607-85bb-a40692d52bba", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "510e7980-1bfa-46dc-a74f-f52804ccd545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f950daf2-d7b9-4607-85bb-a40692d52bba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "199d67b6-783f-4b25-90c5-2e292b38a385", null, "Manager", "MANAGER" },
                    { "ff267017-d2ec-4cb6-b2a0-d94668bb06be", null, "Creator", "CREATOR" }
                });
        }
    }
}
