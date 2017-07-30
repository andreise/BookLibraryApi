using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HomeLibraryApi.Models;

namespace HomeLibraryApi.Migrations
{
    [DbContext(typeof(HomeLibraryContext))]
    [Migration("20170730075343_Model")]
    partial class Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeLibraryApi.Models.Author", b =>
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

            modelBuilder.Entity("HomeLibraryApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPresentOnSite");

                    b.Property<decimal>("Price");

                    b.Property<int>("VolumeId");

                    b.Property<int>("YearOfPurchase");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("VolumeCount");

                    b.HasKey("Id");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Volume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EditionId");

                    b.Property<int>("PageCount");

                    b.Property<int>("YearOfPublication");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("VolumeId");

                    b.Property<int>("WorkKindId");

                    b.Property<int?>("WorkKindId1");

                    b.Property<int>("YearOfCompletion");

                    b.Property<int>("YearOfFirstPublication");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.HasIndex("WorkKindId");

                    b.HasIndex("WorkKindId1");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.WorkKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkKinds");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Author", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Work")
                        .WithMany("Authors")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Book", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Volume", "Volume")
                        .WithMany()
                        .HasForeignKey("VolumeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Volume", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Edition")
                        .WithMany("Volumes")
                        .HasForeignKey("EditionId");
                });

            modelBuilder.Entity("HomeLibraryApi.Models.Work", b =>
                {
                    b.HasOne("HomeLibraryApi.Models.Volume")
                        .WithMany("Works")
                        .HasForeignKey("VolumeId");

                    b.HasOne("HomeLibraryApi.Models.WorkKind", "AltWorkKind")
                        .WithMany()
                        .HasForeignKey("WorkKindId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeLibraryApi.Models.WorkKind", "WorkKind")
                        .WithMany()
                        .HasForeignKey("WorkKindId1");
                });
        }
    }
}
