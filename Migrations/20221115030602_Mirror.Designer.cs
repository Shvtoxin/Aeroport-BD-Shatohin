﻿// <auto-generated />
using System;
using AeroportShatohin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AeroportShatohin.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221115030602_Mirror")]
    partial class Mirror
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Aeroport.Classes.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Build")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ColBuil")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ColPas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Numfl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pass")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeAir")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ADB");
                });
#pragma warning restore 612, 618
        }
    }
}
