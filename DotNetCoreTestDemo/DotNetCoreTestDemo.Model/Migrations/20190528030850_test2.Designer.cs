﻿// <auto-generated />
using System;
using DotNetCoreTestDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreTestDemo.Model.Migrations
{
    [DbContext(typeof(DotNetCoreTestDemoDbContext))]
    [Migration("20190528030850_test2")]
    partial class test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreTestDemo.Model.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(8);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(16);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasMaxLength(16);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
