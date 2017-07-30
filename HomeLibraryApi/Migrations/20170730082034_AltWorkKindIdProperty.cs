using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibraryApi.Migrations
{
    public partial class AltWorkKindIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId1",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "WorkKindId1",
                table: "Works",
                newName: "AltWorkKindId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_WorkKindId1",
                table: "Works",
                newName: "IX_Works_AltWorkKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkKinds_AltWorkKindId",
                table: "Works",
                column: "AltWorkKindId",
                principalTable: "WorkKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkKinds_AltWorkKindId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "AltWorkKindId",
                table: "Works",
                newName: "WorkKindId1");

            migrationBuilder.RenameIndex(
                name: "IX_Works_AltWorkKindId",
                table: "Works",
                newName: "IX_Works_WorkKindId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId1",
                table: "Works",
                column: "WorkKindId1",
                principalTable: "WorkKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
