﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VroomAuto.DataAccess;

namespace VroomAuto.DataAccess.Migrations
{
    [DbContext(typeof(VroomAutoDbContext))]
    [Migration("20200417033526_SecondVroomMigration")]
    partial class SecondVroomMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("VroomAuto.AppLogic.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Km")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ManufacutreDate")
                        .HasColumnType("Date");

                    b.Property<string>("ModelName")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status1")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("BrandName");

                    b.HasIndex("ClassName");

                    b.HasIndex("ModelName");

                    b.HasIndex("Status1");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.CarBrand", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.CarClass", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("CarClasses");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.CarModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.CarStatus", b =>
                {
                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Status");

                    b.ToTable("CarStatuses");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.History", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CarID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("UserID");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.UnwantedUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNP")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("UnwantedUsers");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("CNP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdentityID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.UserType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.Car", b =>
                {
                    b.HasOne("VroomAuto.AppLogic.Models.CarBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandName");

                    b.HasOne("VroomAuto.AppLogic.Models.CarClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassName");

                    b.HasOne("VroomAuto.AppLogic.Models.CarModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelName");

                    b.HasOne("VroomAuto.AppLogic.Models.CarStatus", "Status")
                        .WithMany()
                        .HasForeignKey("Status1");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.History", b =>
                {
                    b.HasOne("VroomAuto.AppLogic.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID");

                    b.HasOne("VroomAuto.AppLogic.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("VroomAuto.AppLogic.Models.User", b =>
                {
                    b.HasOne("VroomAuto.AppLogic.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
