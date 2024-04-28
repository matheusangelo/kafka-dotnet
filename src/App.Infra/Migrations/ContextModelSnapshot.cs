﻿// <auto-generated />
using System;
using App.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace App.Infra.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("ID");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("BODY");

                    b.Property<DateTime>("InsertedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_INSERTED");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_UPDATED");

                    b.HasKey("Id");

                    b.ToTable("MESSAGE", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}