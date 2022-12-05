using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "059d594c-602e-4567-a43f-ebede36d5ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa42b674-7e6b-44e6-8efa-42446c31a81c");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "AssetType",
                keyValue: null,
                column: "AssetType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AssetType",
                table: "Product",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientIdea",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IdeaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdea", x => new { x.ClientId, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_ClientIdea_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientIdea_Idea_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d8a2926-e134-4aee-942b-fb6130f23e2b", null, "Manager", "MANAGER" },
                    { "92b373cd-3500-4fe9-8f3d-8caaecec085a", null, "Creator", "CREATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdea_IdeaId",
                table: "ClientIdea",
                column: "IdeaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientIdea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d8a2926-e134-4aee-942b-fb6130f23e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92b373cd-3500-4fe9-8f3d-8caaecec085a");

            migrationBuilder.AlterColumn<string>(
                name: "AssetType",
                table: "Product",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "059d594c-602e-4567-a43f-ebede36d5ad0", null, "Manager", "MANAGER" },
                    { "fa42b674-7e6b-44e6-8efa-42446c31a81c", null, "Creator", "CREATOR" }
                });
        }
    }
}
