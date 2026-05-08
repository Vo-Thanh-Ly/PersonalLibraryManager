using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalLibraryManager.Migrations
{
    /// <inheritdoc />
    public partial class AddReadingTimeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadingTime",
                table: "Books",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingTime",
                table: "Books");
        }
    }
}
