using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddRiskLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068f6684-df63-4157-adf7-92f5724dc256");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a59895c-6438-45e8-9ab8-bd591e99e8ca");

            migrationBuilder.CreateTable(
                name: "RiskLevel",
                columns: table => new
                {
                    RiskLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskLevel", x => x.RiskLevelId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4d9af92-df52-49e0-b33f-34010abf8a3b", null, "Creator", "CREATOR" },
                    { "fa4c93c6-dcf2-4314-ba1a-9aa1388c9e01", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
            table: "RiskLevel",
            columns: new[] { "RiskLevelId", "Title", "Description"},
            values: new object[,]
            {
                    { "1", "Suitable for very conservative investors", "Investors who hope to experience minimal fluctuations in portfolio value over a rolling one year period and are generally only willing to buy investments that are priced frequently and have a high certainty of being able to sell quickly (less than a week) at a price close to the recently observed market value.\t\t\t\t\r\n" },
                    { "2", "Suitable for conservative investors", "Investors who hope to experience no more than small portfolio losses over a rolling one-year period and are generally only willing to buy investments that are priced frequently and have a high certainty of being able to sell quickly (less than a week) although the investor may at times buy individual investments that entail greater risk.\t\t\t\t\r\n" },
                    { "3", "Suitable for moderate investors", "Investors who hope to experience no more than moderate portfolio losses over a rolling one year period in attempting to enhance longer-term performance and are generally willing to buy investments that are priced frequently and have a high certainty of being able to sell quickly (less than a week) in stable markets although the investor may at times buy individual investments that entail greater risk and are less liquid.\t\t\t\t\r\n" },
                    { "4", "Suitable for aggressive investors", "Investors who are prepared to accept greater portfolio losses over a rolling one year period while attempting to enhance longer-term performance and are willing to buy investments or enter into contracts that may be difficult to sell or close within a short time-frame or have an uncertain realizable value at any given time. \t\t\t\t\r\n" },
                    { "5", "Suitable for very aggressive investors", "Investors who are prepared to accept large portfolio losses up to the value of their entire portfolio over a one year period and are generally willing to buy investments or enter into contracts that may be difficult to sell or close for an extended period or have an uncertain realizable value at any given time. \t\t\t\t\r\n" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskLevel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d9af92-df52-49e0-b33f-34010abf8a3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa4c93c6-dcf2-4314-ba1a-9aa1388c9e01");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068f6684-df63-4157-adf7-92f5724dc256", null, "Manager", "MANAGER" },
                    { "4a59895c-6438-45e8-9ab8-bd591e99e8ca", null, "Creator", "CREATOR" }
                });
        }
    }
}
