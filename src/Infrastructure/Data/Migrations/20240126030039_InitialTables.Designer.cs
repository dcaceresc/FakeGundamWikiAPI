﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240126030039_InitialTables")]
    partial class InitialTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Affiliation", b =>
                {
                    b.Property<int>("AffiliationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AffiliationId"));

                    b.Property<string>("AffiliationName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AffiliationPurpose")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.HasKey("AffiliationId");

                    b.HasIndex("AffiliationName")
                        .IsUnique();

                    b.ToTable("Affiliations");
                });

            modelBuilder.Entity("Domain.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<string>("Aliases")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.HasKey("CharacterId");

                    b.HasIndex("CharacterName")
                        .IsUnique();

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Domain.Entities.CharacterAffiliation", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("AffiliationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.HasKey("CharacterId", "AffiliationId");

                    b.HasIndex("AffiliationId");

                    b.ToTable("CharacterAffiliations");
                });

            modelBuilder.Entity("Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ManufacturerId");

                    b.HasIndex("ManufacturerName")
                        .IsUnique();

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Domain.Entities.MobileSuit", b =>
                {
                    b.Property<int>("MobileSuitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MobileSuitId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FirstSeen")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastSeen")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("MobileSuitName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("MobileSuitId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("MobileSuitName")
                        .IsUnique();

                    b.ToTable("MobileSuits");
                });

            modelBuilder.Entity("Domain.Entities.MobileSuitPilot", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MobileSuitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.HasKey("CharacterId", "MobileSuitId");

                    b.HasIndex("MobileSuitId");

                    b.ToTable("MobileSuitPilots");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("RefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefreshTokenId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("RefreshTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshTokenValue")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RefreshTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.Serie", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SerieId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SerieName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.HasKey("SerieId");

                    b.HasIndex("SerieName")
                        .IsUnique();

                    b.HasIndex("UniverseId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Domain.Entities.Universe", b =>
                {
                    b.Property<int>("UniverseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniverseId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UniverseName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("UniverseId");

                    b.HasIndex("UniverseName")
                        .IsUnique();

                    b.ToTable("Universes");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(30)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.CharacterAffiliation", b =>
                {
                    b.HasOne("Domain.Entities.Affiliation", "Affiliation")
                        .WithMany("CharacterAffiliations")
                        .HasForeignKey("AffiliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Character", "Character")
                        .WithMany("CharacterAffiliations")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Affiliation");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Domain.Entities.MobileSuit", b =>
                {
                    b.HasOne("Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany("MobileSuits")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Domain.Entities.MobileSuitPilot", b =>
                {
                    b.HasOne("Domain.Entities.Character", "Character")
                        .WithMany("MobileSuitPilots")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MobileSuit", "MobileSuit")
                        .WithMany("MobileSuitPilots")
                        .HasForeignKey("MobileSuitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("MobileSuit");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Serie", b =>
                {
                    b.HasOne("Domain.Entities.Universe", "Universe")
                        .WithMany("Series")
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Affiliation", b =>
                {
                    b.Navigation("CharacterAffiliations");
                });

            modelBuilder.Entity("Domain.Entities.Character", b =>
                {
                    b.Navigation("CharacterAffiliations");

                    b.Navigation("MobileSuitPilots");
                });

            modelBuilder.Entity("Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("MobileSuits");
                });

            modelBuilder.Entity("Domain.Entities.MobileSuit", b =>
                {
                    b.Navigation("MobileSuitPilots");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Universe", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
