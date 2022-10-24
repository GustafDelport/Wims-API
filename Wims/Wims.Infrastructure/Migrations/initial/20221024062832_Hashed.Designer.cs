﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wims.Infrastructure.Database_Access;

#nullable disable

namespace Wims.Infrastructure.Migrations.initial
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221024062832_Hashed")]
    partial class Hashed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Wims.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier ")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Category", "dbo");
                });

            modelBuilder.Entity("Wims.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier ");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CostPrice");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description");

                    b.Property<int>("MinThreshold")
                        .HasColumnType("int")
                        .HasColumnName("MinThreshold");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Name");

                    b.Property<int>("QtyInStock")
                        .HasColumnType("int")
                        .HasColumnName("QtyInStock");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SellingPrice");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("Wims.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Wims.Domain.Entities.Product", b =>
                {
                    b.HasOne("Wims.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Wims.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
