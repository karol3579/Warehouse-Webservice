﻿// <auto-generated />
using System;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(SqlRepository))]
    [Migration("20220217180236_datasets3")]
    partial class datasets3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Common.Entities.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Common.Entities.Stock", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("productid")
                        .HasColumnType("char(36)");

                    b.Property<float>("quantity")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Common.Entities.Stock", b =>
                {
                    b.HasOne("Common.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
