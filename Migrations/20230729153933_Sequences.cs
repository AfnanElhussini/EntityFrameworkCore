using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Sequences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_Url",
                table: "Blogs",
                newName: "Index_URL");

            migrationBuilder.CreateSequence<int>(
                name: "BlogNumbers",
                schema: "shared",
                startValue: 1000L,
                incrementBy: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "BlogNumbers",
                schema: "shared");

            migrationBuilder.RenameIndex(
                name: "Index_URL",
                table: "Blogs",
                newName: "IX_Blogs_Url");
        }
    }
}
