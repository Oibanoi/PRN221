using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SignalRAssignment.Models
{
    public partial class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext()
        {
        }

        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        //accounts, customers, orders, orderdetails, products, suppliers
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;   
            }
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStore"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");             

                entity.Property(e => e.CategoryName).HasMaxLength(64);

                entity.Property(e => e.Description).HasMaxLength(1024);
            });

            modelBuilder.Entity<Account>(builder =>
            {
                builder.ToTable("Account");

                builder.HasKey(account => account.AccountID);

                builder.HasIndex(account => account.UserName)
                       .IsUnique();

                builder.Property(account => account.UserName)
                       .IsUnicode(false)
                       .HasMaxLength(30);

                builder.Property(account => account.UserName)
                       .IsUnicode(false)
                       .HasMaxLength(30);

                builder.Property(account => account.Password)
                       .IsUnicode(false)
                       .HasMaxLength(250);

                builder.Property(account => account.FullName)
                       .HasMaxLength(50);

                builder.Property(account => account.Type)
                       .HasDefaultValue((int)AccountType.Member);
            });


            modelBuilder.Entity<Customer>(builder =>
            {
                builder.ToTable("Customers");

                builder.Property(customer => customer.Password)
                       .IsUnicode(false)
                       .HasMaxLength(30);

                builder.Property(customer => customer.ContactName)
                       .HasMaxLength(30);

                builder.Property(customer => customer.Address)
                       .HasMaxLength(500);

                builder.Property(customer => customer.Phone)
                       .IsUnicode(false)
                       .HasMaxLength(15);
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders");

                builder.Property(order => order.OrderDate);

                builder.Property(order => order.RequiredDate)
                       .IsRequired(false);

                builder.Property(order => order.ShippedDate)
                       .IsRequired(false);

                builder.Property(order => order.Freight);

                builder.Property(order => order.ShipAddress)
                       .HasMaxLength(500);

                builder.HasOne(order => order.Customer)
                       .WithMany(customer => customer.Orders)
                       .HasForeignKey(order => order.CustomerID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetail>(builder =>
            {
                builder.ToTable("OrderDetails");

                builder.HasKey(orderDetail => new { orderDetail.OrderID, orderDetail.ProductID });

                builder.Property(orderDetail => orderDetail.UnitPrice);

                builder.Property(orderDetail => orderDetail.Quantity);

                builder.HasOne(orderDetail => orderDetail.Order)
                       .WithMany(order => order.OrderDetails)
                       .HasForeignKey(orderDetail => orderDetail.OrderID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_OrderDetails_Orders");

                builder.HasOne(orderDetail => orderDetail.Product)
                       .WithMany(product => product.OrderDetails)
                       .HasForeignKey(orderDetail => orderDetail.ProductID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Products");

                builder.Property(product => product.ProductName)
                       .HasMaxLength(50);
                

                builder.Property(product => product.UnitPrice);

                builder.Property(product => product.ProductImage)
                       .IsUnicode(false)
                       .HasMaxLength(500);

                builder.HasOne(product => product.Category)
                       .WithMany(category => category.Products)
                       .HasForeignKey(product => product.CategoryID)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Supplier>(builder =>
            {
                builder.ToTable("Suppliers");

                builder.Property(supplier => supplier.CompanyName)
                       .HasMaxLength(50);

                builder.Property(supplier => supplier.Address)
                       .HasMaxLength(500);

                builder.Property(supplier => supplier.Phone)
                       .IsUnicode(false)
                       .HasMaxLength(15);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
