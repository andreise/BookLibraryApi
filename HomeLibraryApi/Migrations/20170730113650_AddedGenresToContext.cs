using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibraryApi.Migrations
{
    public partial class AddedGenresToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Works_WorkId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Works_WorkId1",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_WorkId1",
                table: "Genres",
                newName: "IX_Genres_WorkId1");

            migrationBuilder.RenameIndex(
                name: "IX_Genre_WorkId",
                table: "Genres",
                newName: "IX_Genres_WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Works_WorkId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Works_WorkId1",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_WorkId1",
                table: "Genre",
                newName: "IX_Genre_WorkId1");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_WorkId",
                table: "Genre",
                newName: "IX_Genre_WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Works_WorkId",
                table: "Genre",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Works_WorkId1",
                table: "Genre",
                column: "WorkId1",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
