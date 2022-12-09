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
                keyValue: "05f0267f-bd25-4a5d-abae-f83196e83d92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f06e937e-c947-4a6d-9eae-f51fcf0800ff");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Idea",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
                    { "abcdd5fa-e614-486a-895d-4c54a7399a74", null, "Manager", "MANAGER" },
                    { "e2efed85-61b4-4d4f-b6f0-fb30732e0feb", null, "Creator", "CREATOR" }
                });

            migrationBuilder.InsertData(
                table: "RiskLevel",
                columns: new[] { "RiskLevelId", "Title", "Description" },
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
                keyValue: "abcdd5fa-e614-486a-895d-4c54a7399a74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2efed85-61b4-4d4f-b6f0-fb30732e0feb");

            migrationBuilder.UpdateData(
                table: "Idea",
                keyColumn: "UserID",
                keyValue: null,
                column: "UserID",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Idea",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05f0267f-bd25-4a5d-abae-f83196e83d92", null, "Creator", "CREATOR" },
                    { "f06e937e-c947-4a6d-9eae-f51fcf0800ff", null, "Manager", "MANAGER" }
                });
        }
    }
}
