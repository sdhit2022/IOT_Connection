﻿// <auto-generated />
using System;
using IOT_Connection.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IOT_Connection.Migrations
{
    [DbContext(typeof(IOT_DBContext))]
    [Migration("20241223102324_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IOT_Connection.Models.DeviceDtl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkDeviceHdrId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FkDeviceHdrId");

                    b.ToTable("DeviceDtls");
                });

            modelBuilder.Entity("IOT_Connection.Models.DeviceHdr", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Icon")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SystemCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UniqId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DeviceHdrs");
                });

            modelBuilder.Entity("IOT_Connection.Models.RelUserAndDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("FkDeviceHdrId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FkUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FkDeviceHdrId");

                    b.HasIndex("FkUserId");

                    b.ToTable("RelUserAndDevices");
                });

            modelBuilder.Entity("IOT_Connection.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IOT_Connection.Models.DeviceDtl", b =>
                {
                    b.HasOne("IOT_Connection.Models.DeviceHdr", "DeviceHdr")
                        .WithMany("DeviceDtls")
                        .HasForeignKey("FkDeviceHdrId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DeviceHdr");
                });

            modelBuilder.Entity("IOT_Connection.Models.RelUserAndDevice", b =>
                {
                    b.HasOne("IOT_Connection.Models.DeviceHdr", "DeviceHdr")
                        .WithMany("RelUserAndDevices")
                        .HasForeignKey("FkDeviceHdrId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IOT_Connection.Models.User", "User")
                        .WithMany("RelUserAndDevices")
                        .HasForeignKey("FkUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DeviceHdr");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOT_Connection.Models.DeviceHdr", b =>
                {
                    b.Navigation("DeviceDtls");

                    b.Navigation("RelUserAndDevices");
                });

            modelBuilder.Entity("IOT_Connection.Models.User", b =>
                {
                    b.Navigation("RelUserAndDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
