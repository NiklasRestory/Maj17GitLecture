﻿// <auto-generated />
using System;
using Maj9AspNetDbFK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Maj9AspNetDbFK.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230509072753_Class and Students")]
    partial class ClassandStudents
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Maj9AspNetDbFK.Models.SchoolClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("class_name");

                    b.HasKey("Id");

                    b.ToTable("class");
                });

            modelBuilder.Entity("Maj9AspNetDbFK.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("SchoolClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Maj9AspNetDbFK.Models.Student", b =>
                {
                    b.HasOne("Maj9AspNetDbFK.Models.SchoolClass", null)
                        .WithMany("Students")
                        .HasForeignKey("SchoolClassId");
                });

            modelBuilder.Entity("Maj9AspNetDbFK.Models.SchoolClass", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
