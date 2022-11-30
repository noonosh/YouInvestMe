using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddRiskLevelToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductTag_ProductTagId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d9af92-df52-49e0-b33f-34010abf8a3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa4c93c6-dcf2-4314-ba1a-9aa1388c9e01");

            migrationBuilder.RenameColumn(
                name: "ProductTagId",
                table: "Product",
                newName: "RiskLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTagId",
                table: "Product",
                newName: "IX_Product_RiskLevelId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73691d06-8db7-4072-9921-c05a6ba1c27f", null, "Manager", "MANAGER" },
                    { "ac4e2092-476a-448c-87fd-86191b21358f", null, "Creator", "CREATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_RiskLevel_RiskLevelId",
                table: "Product",
                column: "RiskLevelId",
                principalTable: "RiskLevel",
                principalColumn: "RiskLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_RiskLevel_RiskLevelId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73691d06-8db7-4072-9921-c05a6ba1c27f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac4e2092-476a-448c-87fd-86191b21358f");

            migrationBuilder.RenameColumn(
                name: "RiskLevelId",
                table: "Product",
                newName: "ProductTagId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_RiskLevelId",
                table: "Product",
                newName: "IX_Product_ProductTagId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4d9af92-df52-49e0-b33f-34010abf8a3b", null, "Creator", "CREATOR" },
                    { "fa4c93c6-dcf2-4314-ba1a-9aa1388c9e01", null, "Manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductTag_ProductTagId",
                table: "Product",
                column: "ProductTagId",
                principalTable: "ProductTag",
                principalColumn: "ProductTagId");
        }
    }
}
