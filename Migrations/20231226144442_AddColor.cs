using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeDrawingBoard.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Strokes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Strokes");
        }
    }
}
