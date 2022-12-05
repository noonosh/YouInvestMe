using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d8a2926-e134-4aee-942b-fb6130f23e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92b373cd-3500-4fe9-8f3d-8caaecec085a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1247a135-629e-4ff3-b9da-521cc39f8382", null, "Creator", "CREATOR" },
                    { "ee340795-6019-44c6-a3f5-02253a9f7742", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1247a135-629e-4ff3-b9da-521cc39f8382");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee340795-6019-44c6-a3f5-02253a9f7742");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d8a2926-e134-4aee-942b-fb6130f23e2b", null, "Manager", "MANAGER" },
                    { "92b373cd-3500-4fe9-8f3d-8caaecec085a", null, "Creator", "CREATOR" }
                });
        }
    }
}
