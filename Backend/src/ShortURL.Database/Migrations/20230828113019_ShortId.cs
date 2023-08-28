using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortURL.Database.Migrations
{
    /// <inheritdoc />
    public partial class ShortId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleEntities",
                schema: "app");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "app",
                table: "ShortenedURLs",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "app",
                table: "ShortenedURLs",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "ExampleEntities",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExampleValue1 = table.Column<string>(type: "text", nullable: false),
                    ExampleValue2 = table.Column<int>(type: "integer", nullable: false),
                    ExampleValue3 = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleEntities_ExampleValue1",
                schema: "app",
                table: "ExampleEntities",
                column: "ExampleValue1",
                unique: true);
        }
    }
}
