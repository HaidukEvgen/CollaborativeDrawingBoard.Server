using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollaborativeDrawingBoard.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrawingBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strokes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartPointX = table.Column<int>(type: "int", nullable: false),
                    StartPointY = table.Column<int>(type: "int", nullable: false),
                    EndPointX = table.Column<int>(type: "int", nullable: false),
                    EndPointY = table.Column<int>(type: "int", nullable: false),
                    DrawingBoardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strokes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Strokes_DrawingBoards_DrawingBoardId",
                        column: x => x.DrawingBoardId,
                        principalTable: "DrawingBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Strokes_DrawingBoardId",
                table: "Strokes",
                column: "DrawingBoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strokes");

            migrationBuilder.DropTable(
                name: "DrawingBoards");
        }
    }
}
