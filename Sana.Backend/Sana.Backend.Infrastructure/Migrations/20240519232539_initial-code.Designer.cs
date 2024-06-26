﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sana.Backend.Infrastructure.SQLServer;

#nullable disable

namespace Sana.Backend.Infrastructure.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20240519232539_initial-code")]
    partial class initialcode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relation:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Code")
                        .HasAnnotation("Relational:JsonPropertyName", "code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Description")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.HasKey("Id");

                    b.ToTable("Category", "dbo");

                    b.HasAnnotation("Relational:JsonPropertyName", "category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"),
                            Code = "0001",
                            Description = "Computers"
                        },
                        new
                        {
                            Id = new Guid("b087fc74-f27d-45fe-adec-27230ee0f0e0"),
                            Code = "0002",
                            Description = "Laptops"
                        },
                        new
                        {
                            Id = new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"),
                            Code = "0003",
                            Description = "Tablets"
                        });
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address")
                        .HasAnnotation("Relational:JsonPropertyName", "address");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Cellphone")
                        .HasAnnotation("Relational:JsonPropertyName", "cellphone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("City")
                        .HasAnnotation("Relational:JsonPropertyName", "city");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Document")
                        .HasAnnotation("Relational:JsonPropertyName", "document");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Telephone")
                        .HasAnnotation("Relational:JsonPropertyName", "telephone");

                    b.HasKey("Id");

                    b.ToTable("Customer", "dbo");

                    b.HasAnnotation("Relational:JsonPropertyName", "Customer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a9706c0d-d4c8-4c09-8d87-6dbd3554f5e4"),
                            Address = "Hatillo frente a la iglesia Santa Marta",
                            Cellphone = "3137977225",
                            City = "Barbosa - Antioquia - Colombia",
                            Document = "71775186",
                            Email = "",
                            Name = "Fabian Mauricio Castrillon Franco",
                            Telephone = "3137977225"
                        },
                        new
                        {
                            Id = new Guid("24d55461-85b4-411d-a75c-d20bf80eec7c"),
                            Address = "Calle principal via al Centro Km 12 Casa 3",
                            Cellphone = "4320987771",
                            City = "Los Angeles - California - EEUU",
                            Document = "98123456",
                            Email = "",
                            Name = "Robert C. Martin",
                            Telephone = "4320987771"
                        });
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "customerId");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "document");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order", "dbo");

                    b.HasAnnotation("Relational:JsonPropertyName", "order");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<Guid?>("OrderId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "orderId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "price");

                    b.Property<Guid?>("ProductId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "productId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", "dbo");

                    b.HasAnnotation("Relational:JsonPropertyName", "Items");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasAnnotation("Relational:JsonPropertyName", "CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "price");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "stock");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "UrlImage");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", "dbo");

                    b.HasAnnotation("Relational:JsonPropertyName", "product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fe135d8-1242-448b-b605-092431c2dd45"),
                            CategoryId = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"),
                            Code = "PR001",
                            Name = "Torre Gamer Amd Ryzen 5 5600g +16gb Ram +ssd 240 Radeon 7 P",
                            Price = 1539000m,
                            Stock = 10,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_890513-MCO72408954235_102023-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("37843d1a-daea-47a6-9970-e03faa430190"),
                            CategoryId = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"),
                            Code = "PR002",
                            Name = "Torre Cpu Gamer Athlon 3000g Vega 3 1tb 16gb Led 22 Pc",
                            Price = 1529000m,
                            Stock = 5,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_674835-MCO71845670112_092023-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("aa66e380-29f9-48da-8b2d-6c4cb9cae4fe"),
                            CategoryId = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"),
                            Code = "PR003",
                            Name = "Cpu Torre Core I5 +16ram+hd500 Monitor 19 (Reacondicionado)",
                            Price = 713000m,
                            Stock = 3,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_956627-MCO75513168527_042024-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("c2578b06-94ca-4c9a-b3b5-8c2b4391137f"),
                            CategoryId = new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"),
                            Code = "PR004",
                            Name = "Cpu Intel Core I5 Tercera Generacion Ssd 480 Gb Ram 8gb",
                            Price = 630000m,
                            Stock = 1,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_942517-MCO54964311414_042023-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("228f253b-43e5-4b19-88ea-912c20011c74"),
                            CategoryId = new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"),
                            Code = "PR005",
                            Name = "Apple iPad (9ª generación) 10.2\" Wi-Fi 64GB - Gris espacial ",
                            Price = 2200000m,
                            Stock = 2,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_912069-MLA74807972777_022024-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("8485b9bb-c0d7-45e5-bfb3-a9966851baf9"),
                            CategoryId = new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"),
                            Code = "PR006",
                            Name = "iPad Apple Pro 4th generation 4th generation A2759 11\" 128GB gris espacial y 8GB de memoria RAM ",
                            Price = 3500000m,
                            Stock = 1,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_893788-MLA52850734025_122022-O.jpg"
                        },
                        new
                        {
                            Id = new Guid("4ba835ec-351a-4bff-8582-27664624e0fd"),
                            CategoryId = new Guid("b087fc74-f27d-45fe-adec-27230ee0f0e0"),
                            Code = "PR007",
                            Name = "Mac Air 2020 Pulgadas I7 + 16gb + 500 Ssd Como Nuevo En Caja",
                            Price = 5800000m,
                            Stock = 1,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_607176-MCO69416858664_052023-O.jpg"
                        });
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Order", b =>
                {
                    b.HasOne("Sana.Backend.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Sana.Backend.Domain.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sana.Backend.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Product", b =>
                {
                    b.HasOne("Sana.Backend.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Sana.Backend.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
