using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortURL.Database.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "ExampleEntities",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExampleValue1 = table.Column<string>(type: "text", nullable: false),
                    ExampleValue2 = table.Column<int>(type: "integer", nullable: false),
                    ExampleValue3 = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortenedURLs",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedURLs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleEntities_ExampleValue1",
                schema: "app",
                table: "ExampleEntities",
                column: "ExampleValue1",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleEntities",
                schema: "app");

            migrationBuilder.DropTable(
                name: "ShortenedURLs",
                schema: "app");
        }
    }
}
