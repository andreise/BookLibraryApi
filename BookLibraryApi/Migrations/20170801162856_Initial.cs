using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookLibraryApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VolumeCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionId = table.Column<int>(nullable: true),
                    PageCount = table.Column<int>(nullable: true),
                    YearOfPublication = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volumes_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
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

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AltGenreId = table.Column<int>(nullable: true),
                    AltWorkKindId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VolumeId = table.Column<int>(nullable: true),
                    WorkKindId = table.Column<int>(nullable: true),
                    YearOfCompletion = table.Column<int>(nullable: true),
                    YearOfFirstPublication = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Genres_AltGenreId",
                        column: x => x.AltGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_WorkKinds_AltWorkKindId",
                        column: x => x.AltWorkKindId,
                        principalTable: "WorkKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_WorkKinds_WorkKindId",
                        column: x => x.WorkKindId,
                        principalTable: "WorkKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EditionVolumeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditionId = table.Column<int>(nullable: false),
                    VolumeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionVolumeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionVolumeLinks_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionVolumeLinks_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WorkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolumeWorkLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VolumeId = table.Column<int>(nullable: false),
                    WorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolumeWorkLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolumeWorkLinks_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolumeWorkLinks_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkAuthorLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    WorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAuthorLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkAuthorLinks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkAuthorLinks_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_WorkId",
                table: "Authors",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_EditionId",
                table: "Volumes",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_VolumeExemplars_VolumeId",
                table: "VolumeExemplars",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_AltGenreId",
                table: "Works",
                column: "AltGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_AltWorkKindId",
                table: "Works",
                column: "AltWorkKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_GenreId",
                table: "Works",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_VolumeId",
                table: "Works",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkKindId",
                table: "Works",
                column: "WorkKindId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionVolumeLinks_EditionId",
                table: "EditionVolumeLinks",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionVolumeLinks_VolumeId",
                table: "EditionVolumeLinks",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_VolumeWorkLinks_VolumeId",
                table: "VolumeWorkLinks",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_VolumeWorkLinks_WorkId",
                table: "VolumeWorkLinks",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAuthorLinks_AuthorId",
                table: "WorkAuthorLinks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAuthorLinks_WorkId",
                table: "WorkAuthorLinks",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolumeExemplars");

            migrationBuilder.DropTable(
                name: "EditionVolumeLinks");

            migrationBuilder.DropTable(
                name: "VolumeWorkLinks");

            migrationBuilder.DropTable(
                name: "WorkAuthorLinks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "WorkKinds");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropTable(
                name: "Editions");
        }
    }
}
