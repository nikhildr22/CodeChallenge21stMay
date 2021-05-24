﻿// <auto-generated />
using FurnitureStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FurnitureStoreAPI.Migrations
{
    [DbContext(typeof(FurnitureStoreDbContext))]
    partial class FurnitureStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FurnitureStoreAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FurnitureStoreAPI.Models.CustomerFurniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FurnitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FurnitureId");

                    b.ToTable("CustomerFurnitures");
                });

            modelBuilder.Entity("FurnitureStoreAPI.Models.Furniture", b =>
                {
                    b.Property<int>("FurnitureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FurnitureId");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("FurnitureStoreAPI.Models.CustomerFurniture", b =>
                {
                    b.HasOne("FurnitureStoreAPI.Models.Customer", "Customer")
                        .WithMany("CustomerFurnitures")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FurnitureStoreAPI.Models.Furniture", "Furniture")
                        .WithMany("CustomerFurnitures")
                        .HasForeignKey("FurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Furniture");
                });

            modelBuilder.Entity("FurnitureStoreAPI.Models.Customer", b =>
                {
                    b.Navigation("CustomerFurnitures");
                });

            modelBuilder.Entity("FurnitureStoreAPI.Models.Furniture", b =>
                {
                    b.Navigation("CustomerFurnitures");
                });
#pragma warning restore 612, 618
        }
    }
}
