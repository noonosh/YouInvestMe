using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddFKRiskValueForClientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "323b7c8a-a116-4fdc-8f97-6f732a6bd522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3672e307-5926-416a-949e-63e6860df1e0");

            migrationBuilder.RenameColumn(
                name: "RiskValue",
                table: "Client",
                newName: "RiskLevelId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "059d594c-602e-4567-a43f-ebede36d5ad0", null, "Manager", "MANAGER" },
                    { "fa42b674-7e6b-44e6-8efa-42446c31a81c", null, "Creator", "CREATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_RiskLevelId",
                table: "Client",
                column: "RiskLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_RiskLevel_RiskLevelId",
                table: "Client",
                column: "RiskLevelId",
                principalTable: "RiskLevel",
                principalColumn: "RiskLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_RiskLevel_RiskLevelId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_RiskLevelId",
                table: "Client");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "059d594c-602e-4567-a43f-ebede36d5ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa42b674-7e6b-44e6-8efa-42446c31a81c");

            migrationBuilder.RenameColumn(
                name: "RiskLevelId",
                table: "Client",
                newName: "RiskValue");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "323b7c8a-a116-4fdc-8f97-6f732a6bd522", null, "Creator", "CREATOR" },
                    { "3672e307-5926-416a-949e-63e6860df1e0", null, "Manager", "MANAGER" }
                });
        }
    }
}
