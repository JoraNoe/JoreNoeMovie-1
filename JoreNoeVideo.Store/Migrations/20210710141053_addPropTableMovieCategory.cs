using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class addPropTableMovieCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderBy",
                table: "MovieCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderBy",
                table: "MovieCategorys");
        }
    }
}
