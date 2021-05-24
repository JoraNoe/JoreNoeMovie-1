using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class addPropa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MovieDescqeId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "CarouseMaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieDescqeId",
                table: "Movies",
                column: "MovieDescqeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieDescs_MovieDescqeId",
                table: "Movies",
                column: "MovieDescqeId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieDescs_MovieDescqeId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieDescqeId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieDescqeId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "CarouseMaps");
        }
    }
}
