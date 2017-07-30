using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibraryApi.Migrations
{
    public partial class NullablePropsAndFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId",
                table: "Works");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfFirstPublication",
                table: "Works",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "YearOfCompletion",
                table: "Works",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WorkKindId",
                table: "Works",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "YearOfPublication",
                table: "Volumes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Volumes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "VolumeCount",
                table: "Editions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "YearOfPurchase",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPresentOnSite",
                table: "Books",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId",
                table: "Works",
                column: "WorkKindId",
                principalTable: "WorkKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId",
                table: "Works");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfFirstPublication",
                table: "Works",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearOfCompletion",
                table: "Works",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkKindId",
                table: "Works",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearOfPublication",
                table: "Volumes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PageCount",
                table: "Volumes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VolumeCount",
                table: "Editions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearOfPurchase",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPresentOnSite",
                table: "Books",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Volumes_VolumeId",
                table: "Books",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_WorkKinds_WorkKindId",
                table: "Works",
                column: "WorkKindId",
                principalTable: "WorkKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
