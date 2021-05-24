using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class EditMovieProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategorys_MovieDescs_CategoryId",
                table: "MovieCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDescs_MovieMindCollections_MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieDescs_MovieDescqeId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MovieMindCollections");

            migrationBuilder.DropIndex(
                name: "IX_MovieDescs_MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MovieDescs");

            migrationBuilder.DropColumn(
                name: "MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.RenameColumn(
                name: "MovieDescqeId",
                table: "Movies",
                newName: "MovieDesctionId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MovieDescqeId",
                table: "Movies",
                newName: "IX_Movies_MovieDesctionId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "MovieCategorys",
                newName: "MovieDescId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCategorys_CategoryId",
                table: "MovieCategorys",
                newName: "IX_MovieCategorys_MovieDescId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategorys_MovieDescs_MovieDescId",
                table: "MovieCategorys",
                column: "MovieDescId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieDescs_MovieDesctionId",
                table: "Movies",
                column: "MovieDesctionId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategorys_MovieDescs_MovieDescId",
                table: "MovieCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieDescs_MovieDesctionId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "MovieDesctionId",
                table: "Movies",
                newName: "MovieDescqeId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_MovieDesctionId",
                table: "Movies",
                newName: "IX_Movies_MovieDescqeId");

            migrationBuilder.RenameColumn(
                name: "MovieDescId",
                table: "MovieCategorys",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCategorys_MovieDescId",
                table: "MovieCategorys",
                newName: "IX_MovieCategorys_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "MovieDescs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieCollectionsId",
                table: "MovieDescs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MovieMindCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MoviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMindCollections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDescs_MovieCollectionsId",
                table: "MovieDescs",
                column: "MovieCollectionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategorys_MovieDescs_CategoryId",
                table: "MovieCategorys",
                column: "CategoryId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDescs_MovieMindCollections_MovieCollectionsId",
                table: "MovieDescs",
                column: "MovieCollectionsId",
                principalTable: "MovieMindCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieDescs_MovieDescqeId",
                table: "Movies",
                column: "MovieDescqeId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
