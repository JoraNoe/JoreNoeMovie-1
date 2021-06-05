using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class AddNewProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisLikes",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MovieCategory",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "MovieDescs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "MovieCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserLikeMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikeMovies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikeMovies");

            migrationBuilder.DropColumn(
                name: "DisLikes",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieCategory",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieDescs");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieCollections");
        }
    }
}
