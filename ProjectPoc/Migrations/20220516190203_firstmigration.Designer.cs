﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectPoc.Model;

#nullable disable

namespace ProjectPoc.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220516190203_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectPoc.Model.Project", b =>
                {
                    b.Property<Guid?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("licenseEmail")
                        .HasColumnType("text");

                    b.Property<DateTime?>("licenseExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("licenseId")
                        .HasColumnType("uuid");

                    b.Property<string>("licenseName")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
