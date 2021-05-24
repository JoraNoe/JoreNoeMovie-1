using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class AddForkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategorys_MovieDescs_MovieDescId",
                table: "MovieCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieDescId",
                table: "MovieCollections");

            migrationBuilder.RenameColumn(
                name: "MovieDescId",
                table: "MovieCollections",
                newName: "MovieCollectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollections_MovieDescId",
                table: "MovieCollections",
                newName: "IX_MovieCollections_MovieCollectionsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategorys_MovieDescs_CategoryId",
                table: "MovieCategorys",
                column: "CategoryId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieCollectionsId",
                table: "MovieCollections",
                column: "MovieCollectionsId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategorys_MovieDescs_CategoryId",
                table: "MovieCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieCollectionsId",
                table: "MovieCollections");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MovieDescs");

            migrationBuilder.DropColumn(
                name: "MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.RenameColumn(
                name: "MovieCollectionsId",
                table: "MovieCollections",
                newName: "MovieDescId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollections_MovieCollectionsId",
                table: "MovieCollections",
                newName: "IX_MovieCollections_MovieDescId");

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
                name: "FK_MovieCollections_MovieDescs_MovieDescId",
                table: "MovieCollections",
                column: "MovieDescId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
