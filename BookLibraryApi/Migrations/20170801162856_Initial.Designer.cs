using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookLibraryApi.Models.Contexts;

namespace BookLibraryApi.Migrations
{
    [DbContext(typeof(BookLibraryContext))]
    [Migration("20170801162856_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("VolumeCount");

                    b.HasKey("Id");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Volume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EditionId");

                    b.Property<int?>("PageCount");

                    b.Property<int?>("YearOfPublication");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.VolumeExemplar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryNumber");

                    b.Property<bool?>("IsInPlace");

                    b.Property<decimal?>("Price");

                    b.Property<int?>("VolumeId");

                    b.Property<int?>("YearOfPurchase");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("VolumeExemplars");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AltGenreId");

                    b.Property<int?>("AltWorkKindId");

                    b.Property<string>("Description");

                    b.Property<int?>("GenreId");

                    b.Property<string>("Name");

                    b.Property<int?>("VolumeId");

                    b.Property<int?>("WorkKindId");

                    b.Property<int?>("YearOfCompletion");

                    b.Property<int?>("YearOfFirstPublication");

                    b.HasKey("Id");

                    b.HasIndex("AltGenreId");

                    b.HasIndex("AltWorkKindId");

                    b.HasIndex("GenreId");

                    b.HasIndex("VolumeId");

                    b.HasIndex("WorkKindId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.WorkKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkKinds");
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.EditionVolumeLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EditionId");

                    b.Property<int>("VolumeId");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("VolumeId");

                    b.ToTable("EditionVolumeLinks");
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.VolumeWorkLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("VolumeId");

                    b.Property<int>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.HasIndex("WorkId");

                    b.ToTable("VolumeWorkLinks");
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.WorkAuthorLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("WorkId");

                    b.ToTable("WorkAuthorLinks");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Author", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Work")
                        .WithMany("Authors")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Volume", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Edition")
                        .WithMany("Volumes")
                        .HasForeignKey("EditionId");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.VolumeExemplar", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Volume", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId");
                });

            modelBuilder.Entity("BookLibraryApi.Models.Entities.Work", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Genre", "AltGenre")
                        .WithMany()
                        .HasForeignKey("AltGenreId");

                    b.HasOne("BookLibraryApi.Models.Entities.WorkKind", "AltWorkKind")
                        .WithMany()
                        .HasForeignKey("AltWorkKindId");

                    b.HasOne("BookLibraryApi.Models.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("BookLibraryApi.Models.Entities.Volume")
                        .WithMany("Works")
                        .HasForeignKey("VolumeId");

                    b.HasOne("BookLibraryApi.Models.Entities.WorkKind", "WorkKind")
                        .WithMany()
                        .HasForeignKey("WorkKindId");
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.EditionVolumeLink", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibraryApi.Models.Entities.Volume", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.VolumeWorkLink", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Volume", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibraryApi.Models.Entities.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookLibraryApi.Models.EntityLinks.WorkAuthorLink", b =>
                {
                    b.HasOne("BookLibraryApi.Models.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookLibraryApi.Models.Entities.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
