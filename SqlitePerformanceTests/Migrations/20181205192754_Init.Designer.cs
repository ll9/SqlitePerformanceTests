﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqlitePerformanceTests.Data;

namespace SqlitePerformanceTests.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181205192754_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("SqlitePerformanceTests.Models.Lichtpunkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hausnummer");

                    b.Property<string>("Ort");

                    b.Property<string>("Straße");

                    b.HasKey("Id");

                    b.ToTable("Lichtpunkt");
                });
#pragma warning restore 612, 618
        }
    }
}