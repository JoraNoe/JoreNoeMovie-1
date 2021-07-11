using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class addtablepropUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryUrl",
                table: "MovieCategorys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryUrl",
                table: "MovieCategorys");
        }
    }
}
