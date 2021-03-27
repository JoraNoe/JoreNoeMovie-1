using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class AddForkey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieCollectionsId",
                table: "MovieCollections");

            migrationBuilder.RenameColumn(
                name: "MovieCollectionsId",
                table: "MovieCollections",
                newName: "MovieDescId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollections_MovieCollectionsId",
                table: "MovieCollections",
                newName: "IX_MovieCollections_MovieDescId");

            migrationBuilder.CreateTable(
                name: "MovieMindCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "FK_MovieCollections_MovieDescs_MovieDescId",
                table: "MovieCollections",
                column: "MovieDescId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieDescId",
                table: "MovieCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDescs_MovieMindCollections_MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.DropTable(
                name: "MovieMindCollections");

            migrationBuilder.DropIndex(
                name: "IX_MovieDescs_MovieCollectionsId",
                table: "MovieDescs");

            migrationBuilder.RenameColumn(
                name: "MovieDescId",
                table: "MovieCollections",
                newName: "MovieCollectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCollections_MovieDescId",
                table: "MovieCollections",
                newName: "IX_MovieCollections_MovieCollectionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCollections_MovieDescs_MovieCollectionsId",
                table: "MovieCollections",
                column: "MovieCollectionsId",
                principalTable: "MovieDescs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
