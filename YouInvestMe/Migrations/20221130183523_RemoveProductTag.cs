using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73691d06-8db7-4072-9921-c05a6ba1c27f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4e2092-476a-448c-87fd-86191b21358f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b9f5ff9-67a3-4bdd-b96e-b3bd8bf54114", null, "Manager", "MANAGER" },
                    { "cf47f106-7f81-4c0f-9197-cbf600f38229", null, "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b9f5ff9-67a3-4bdd-b96e-b3bd8bf54114");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf47f106-7f81-4c0f-9197-cbf600f38229");

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.ProductTagId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73691d06-8db7-4072-9921-c05a6ba1c27f", null, "Manager", "MANAGER" },
                    { "ac4e2092-476a-448c-87fd-86191b21358f", null, "Creator", "CREATOR" }
                });
        }
    }
}
