﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealState.Repository;

#nullable disable

namespace RealState.Repository.Migrations
{
    [DbContext(typeof(RealStateDbContext))]
    [Migration("20240820085315_FirstCreateDb")]
    partial class FirstCreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealState.Repository.Entity.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Admin_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Building_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("RealState.Repository.Entity.BuildingSociety", b =>
                {
                    b.Property<int>("SocietyID")
                        .HasColumnType("int");

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.HasKey("SocietyID", "BuildingID");

                    b.HasIndex("BuildingID");

                    b.ToTable("BuildingSocieties");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Parking_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("No_Of_Floor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Society", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Society_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Society_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Society_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("RealState.Repository.Entity.BuildingSociety", b =>
                {
                    b.HasOne("RealState.Repository.Entity.Building", "Building")
                        .WithMany("BuildingSocieties")
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealState.Repository.Entity.Society", "Society")
                        .WithMany("BuildingSocieties")
                        .HasForeignKey("SocietyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Parking", b =>
                {
                    b.HasOne("RealState.Repository.Entity.Room", "Room")
                        .WithOne("Parking")
                        .HasForeignKey("RealState.Repository.Entity.Parking", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Room", b =>
                {
                    b.HasOne("RealState.Repository.Entity.Building", "Building")
                        .WithMany("Room")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Building", b =>
                {
                    b.Navigation("BuildingSocieties");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RealState.Repository.Entity.Room", b =>
                {
                    b.Navigation("Parking")
                        .IsRequired();
                });

            modelBuilder.Entity("RealState.Repository.Entity.Society", b =>
                {
                    b.Navigation("BuildingSocieties");
                });
#pragma warning restore 612, 618
        }
    }
}
