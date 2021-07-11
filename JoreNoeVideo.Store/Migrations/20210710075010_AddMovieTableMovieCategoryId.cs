using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class AddMovieTableMovieCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieCategoryId",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieCategoryId",
                table: "Movies");
        }
    }
}
