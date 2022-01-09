using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAndMovie.Data.Migrations
{
    public partial class addMovieDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Review",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovieUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FilmGenre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Watched = table.Column<bool>(type: "bit", nullable: false),
                    Review = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "bookId",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
