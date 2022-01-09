using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAndMovie.Data.Migrations
{
    public partial class updateBookDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bookUrl",
                table: "Books",
                newName: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "Books",
                newName: "bookUrl");
        }
    }
}
