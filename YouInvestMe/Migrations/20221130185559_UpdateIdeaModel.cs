using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouInvestMe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdeaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Idea",
                newName: "Region");

            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Idea",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Idea",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Idea",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiriesDate",
                table: "Idea",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Instruments",
                table: "Idea",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Idea",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Idea",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "ExpiriesDate",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "Instruments",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Idea");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Idea",
                newName: "Description");
        }
    }
}
