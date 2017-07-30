using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibraryApi.Migrations
{
    public partial class FixedWorksGenreLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Works_WorkId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Works_WorkId1",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_WorkId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_WorkId1",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "WorkId1",
                table: "Genres");

            migrationBuilder.CreateIndex(
                name: "IX_Works_AltGenreId",
                table: "Works",
                column: "AltGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_GenreId",
                table: "Works",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Genres_AltGenreId",
                table: "Works",
                column: "AltGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Genres_GenreId",
                table: "Works",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Genres_AltGenreId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Genres_GenreId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_AltGenreId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_GenreId",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Genres",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkId1",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_WorkId",
                table: "Genres",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_WorkId1",
                table: "Genres",
                column: "WorkId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Works_WorkId",
                table: "Genres",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Works_WorkId1",
                table: "Genres",
                column: "WorkId1",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
