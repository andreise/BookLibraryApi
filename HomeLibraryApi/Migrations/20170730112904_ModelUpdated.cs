using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeLibraryApi.Migrations
{
    public partial class ModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AltGenreId",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Works",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WorkId = table.Column<int>(nullable: true),
                    WorkId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genre_Works_WorkId1",
                        column: x => x.WorkId1,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolumeExemplars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryNumber = table.Column<string>(nullable: true),
                    IsInPlace = table.Column<bool>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    VolumeId = table.Column<int>(nullable: true),
                    YearOfPurchase = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolumeExemplars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolumeExemplars_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_WorkId",
                table: "Genre",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_WorkId1",
                table: "Genre",
                column: "WorkId1");

            migrationBuilder.CreateIndex(
                name: "IX_VolumeExemplars_VolumeId",
                table: "VolumeExemplars",
                column: "VolumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "VolumeExemplars");

            migrationBuilder.DropColumn(
                name: "AltGenreId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Works");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPresentOnSite = table.Column<bool>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    VolumeId = table.Column<int>(nullable: true),
                    YearOfPurchase = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_VolumeId",
                table: "Books",
                column: "VolumeId");
        }
    }
}
