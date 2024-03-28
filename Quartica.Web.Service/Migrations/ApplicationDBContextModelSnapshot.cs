﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quartica.Web.Service.DdContextConfiguration;

#nullable disable

namespace Quartica.Web.Service.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Quartica.Web.Service.Models.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("activities");
                });

            modelBuilder.Entity("Quartica.Web.Service.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Quartica.Web.Service.Models.UserAuditLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ActivityId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<long?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ValueAfter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueBefore")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("userAuditLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
