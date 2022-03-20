﻿// <auto-generated />
using System;
using DataManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220320122154_AddedDifficultyColumn")]
    partial class AddedDifficultyColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataManager.Model.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CalibrationGrade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ComplitionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DistanceBetweenDisplayAndUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LightSurrounding")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QOVision")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScreenDisplaySize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TimeSpentToComplete")
                        .HasColumnType("integer");

                    b.Property<string>("UserAge")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Performances");
                });
#pragma warning restore 612, 618
        }
    }
}
