using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JoreNoeVideo.Store.Migrations
{
    public partial class AddTables_Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmericanOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmericanOperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimationOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationOperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HongKongOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HongKongOperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KoreanDramaOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoreanDramaOperas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainlandOperas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainlandOperas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmericanOperas");

            migrationBuilder.DropTable(
                name: "AnimationOperas");

            migrationBuilder.DropTable(
                name: "FilmOperas");

            migrationBuilder.DropTable(
                name: "HongKongOperas");

            migrationBuilder.DropTable(
                name: "KoreanDramaOperas");

            migrationBuilder.DropTable(
                name: "MainlandOperas");
        }
    }
}
