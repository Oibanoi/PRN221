﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalRAssignment.Models;

#nullable disable

namespace SignalRAssignment.Migrations
{
    [DbContext(typeof(PizzaStoreContext))]
    [Migration("20230619063644_revert")]
    partial class revert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SignalRAssignment.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("AccountID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Freight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuantityPerUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("SignalRAssignment.Models.Order", b =>
                {
                    b.HasOne("SignalRAssignment.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Customers");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SignalRAssignment.Models.OrderDetail", b =>
                {
                    b.HasOne("SignalRAssignment.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDetails_Orders");

                    b.HasOne("SignalRAssignment.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDetails_Products");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Product", b =>
                {
                    b.HasOne("SignalRAssignment.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .IsRequired()
                        .HasConstraintName("FK_Products_Categories");

                    b.HasOne("SignalRAssignment.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .IsRequired()
                        .HasConstraintName("FK_Products_Suppliers");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SignalRAssignment.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
