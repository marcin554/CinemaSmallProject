﻿// <auto-generated />
using System;
using BerrasBioMarcin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerrasBioMarcin.Migrations
{
    [DbContext(typeof(BerrasBioMarcinContext))]
    [Migration("20220422123645_MessV11")]
    partial class MessV11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerrasBioMarcin.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CinemaId"), 1L, 1);

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinema");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("MoviePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MovieReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieTitleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Salon", b =>
                {
                    b.Property<int>("SalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalonId"), 1L, 1);

                    b.Property<int>("AvailableSpace")
                        .HasColumnType("int");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("SalonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Show", b =>
                {
                    b.Property<int>("ShowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowID"), 1L, 1);

                    b.Property<bool>("IsShowCanceled")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("SalonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ShowID");

                    b.HasIndex("MovieId");

                    b.HasIndex("SalonId");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Movie", b =>
                {
                    b.HasOne("BerrasBioMarcin.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Salon", b =>
                {
                    b.HasOne("BerrasBioMarcin.Models.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Show", b =>
                {
                    b.HasOne("BerrasBioMarcin.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerrasBioMarcin.Models.Salon", null)
                        .WithMany("Shows")
                        .HasForeignKey("SalonId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BerrasBioMarcin.Models.Salon", b =>
                {
                    b.Navigation("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
