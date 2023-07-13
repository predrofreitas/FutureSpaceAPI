﻿// <auto-generated />
using System;
using FutureSpaceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FutureSpaceAPI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LaunchLibraryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Variant")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.LaunchServiceProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LaunchServiceProviders");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Launcher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FailReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hashtag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoldReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("InHold")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LaunchLibraryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LaunchServiceProviderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Net")
                        .HasColumnType("TEXT");

                    b.Property<int>("PadId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Probability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RocketId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TbdDate")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TbdTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("WebcastLive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WindowEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WindowStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LaunchServiceProviderId");

                    b.HasIndex("PadId");

                    b.HasIndex("RocketId");

                    b.HasIndex("StatusId");

                    b.ToTable("Launchers");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MapImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalLandingCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalLaunchCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Pad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InfoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MapImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MapUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalLaunchCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WikiUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Pads");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Rocket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Rockets");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Launcher", b =>
                {
                    b.HasOne("FutureSpaceAPI.Domain.Entities.LaunchServiceProvider", "LaunchServiceProvider")
                        .WithMany()
                        .HasForeignKey("LaunchServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FutureSpaceAPI.Domain.Entities.Pad", "Pad")
                        .WithMany()
                        .HasForeignKey("PadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FutureSpaceAPI.Domain.Entities.Rocket", "Rocket")
                        .WithMany()
                        .HasForeignKey("RocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FutureSpaceAPI.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaunchServiceProvider");

                    b.Navigation("Pad");

                    b.Navigation("Rocket");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Pad", b =>
                {
                    b.HasOne("FutureSpaceAPI.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("FutureSpaceAPI.Domain.Entities.Rocket", b =>
                {
                    b.HasOne("FutureSpaceAPI.Domain.Entities.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");
                });
#pragma warning restore 612, 618
        }
    }
}
