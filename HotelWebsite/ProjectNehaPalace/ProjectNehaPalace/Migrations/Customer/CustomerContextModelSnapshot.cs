﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProjectNehaPalace.Models;
using System;

namespace ProjectNehaPalace.Migrations.Customer
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectNehaPalace.Models.HotelViewModels.Address", b =>
                {
                    b.Property<string>("AddressID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressType");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("AddressID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ProjectNehaPalace.Models.HotelViewModels.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PersonID");

                    b.HasKey("CustomerID");

                    b.HasIndex("PersonID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ProjectNehaPalace.Models.HotelViewModels.Person", b =>
                {
                    b.Property<string>("PersonID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("PersonID");

                    b.HasIndex("AddressID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ProjectNehaPalace.Models.HotelViewModels.Customer", b =>
                {
                    b.HasOne("ProjectNehaPalace.Models.HotelViewModels.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("ProjectNehaPalace.Models.HotelViewModels.Person", b =>
                {
                    b.HasOne("ProjectNehaPalace.Models.HotelViewModels.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");
                });
#pragma warning restore 612, 618
        }
    }
}