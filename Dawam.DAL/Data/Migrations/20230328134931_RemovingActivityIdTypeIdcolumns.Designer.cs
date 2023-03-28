﻿// <auto-generated />
using System;
using Dawam.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dawam.DAL.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230328134931_RemovingActivityIdTypeIdcolumns")]
    partial class RemovingActivityIdTypeIdcolumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dawam.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<byte>("Editor")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.Waqf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ConfirmDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ConfirmUserId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DocumentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EstablishmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EstablishmentDateH")
                        .HasColumnType("datetime2");

                    b.Property<string>("FounderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsUserId")
                        .HasColumnType("int");

                    b.Property<int?>("WaqfActivityId")
                        .HasColumnType("int");

                    b.Property<string>("WaqfDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaqfName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaqfStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("WaqfTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ConfirmUserId");

                    b.HasIndex("CountryId");

                    b.HasIndex("InsUserId");

                    b.HasIndex("WaqfActivityId");

                    b.HasIndex("WaqfStatusId");

                    b.HasIndex("WaqfTypeId");

                    b.ToTable("Waqfs");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.WaqfActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaqfActivities");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.WaqfStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaqfStatuses");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.WaqfType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaqfTypes");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.City", b =>
                {
                    b.HasOne("Dawam.DAL.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.User", b =>
                {
                    b.HasOne("Dawam.DAL.Entities.City", "city")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Dawam.DAL.Entities.Country", "country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("city");

                    b.Navigation("country");
                });

            modelBuilder.Entity("Dawam.DAL.Entities.Waqf", b =>
                {
                    b.HasOne("Dawam.DAL.Entities.City", "WaqfCity")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Dawam.DAL.Entities.User", "ConfirmUser")
                        .WithMany()
                        .HasForeignKey("ConfirmUserId");

                    b.HasOne("Dawam.DAL.Entities.Country", "WaqfCountry")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Dawam.DAL.Entities.User", "InsUser")
                        .WithMany()
                        .HasForeignKey("InsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dawam.DAL.Entities.WaqfActivity", "WaqfActivity")
                        .WithMany()
                        .HasForeignKey("WaqfActivityId");

                    b.HasOne("Dawam.DAL.Entities.WaqfStatus", "WaqfStatus")
                        .WithMany()
                        .HasForeignKey("WaqfStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dawam.DAL.Entities.WaqfType", "WaqfType")
                        .WithMany()
                        .HasForeignKey("WaqfTypeId");

                    b.Navigation("ConfirmUser");

                    b.Navigation("InsUser");

                    b.Navigation("WaqfActivity");

                    b.Navigation("WaqfCity");

                    b.Navigation("WaqfCountry");

                    b.Navigation("WaqfStatus");

                    b.Navigation("WaqfType");
                });
#pragma warning restore 612, 618
        }
    }
}
