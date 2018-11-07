﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Repository;
using System;

namespace Test.Migrations
{
    [DbContext(typeof(PosDbContext))]
    partial class PosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Model.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<string>("Note");

                    b.Property<short?>("Status")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Test.Model.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<double>("Due");

                    b.Property<string>("Email");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Paid");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Test.Model.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("SupplierId");

                    b.Property<string>("UnitMeasurement")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Test.Model.Purchase", b =>
                {
                    b.Property<Guid>("PurchaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<double>("Due");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<int>("NoOfItem");

                    b.Property<string>("Note");

                    b.Property<double>("Paid");

                    b.Property<Guid?>("SupplierId");

                    b.Property<double>("TotalAmount");

                    b.HasKey("PurchaseId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Test.Model.PurchaseDetails", b =>
                {
                    b.Property<Guid>("PurchaseDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MeasureType")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("PurchaseId");

                    b.Property<int>("Quantity");

                    b.HasKey("PurchaseDetailsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetailses");
                });

            modelBuilder.Entity("Test.Model.Sale", b =>
                {
                    b.Property<Guid>("SaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<Guid?>("CustomerId");

                    b.Property<double?>("Discount");

                    b.Property<double?>("Due");

                    b.Property<string>("InvoiceNo");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<int>("NoOfItem");

                    b.Property<string>("Note");

                    b.Property<double>("Paid");

                    b.Property<double>("TotalAmount");

                    b.HasKey("SaleId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Test.Model.SaleDetails", b =>
                {
                    b.Property<Guid>("SaleDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<string>("MeasureType")
                        .IsRequired();

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<double>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("SaleId");

                    b.HasKey("SaleDetailsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleDetailses");
                });

            modelBuilder.Entity("Test.Model.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Company");

                    b.Property<DateTime>("Create");

                    b.Property<Guid>("CreateBy");

                    b.Property<double>("Due");

                    b.Property<string>("Email");

                    b.Property<DateTime>("Modify");

                    b.Property<Guid>("ModifyBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Note");

                    b.Property<double>("Paid");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Test.Model.Product", b =>
                {
                    b.HasOne("Repository.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Test.Model.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Test.Model.Purchase", b =>
                {
                    b.HasOne("Test.Model.Supplier", "Supplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Test.Model.PurchaseDetails", b =>
                {
                    b.HasOne("Test.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Test.Model.Purchase", "Purchase")
                        .WithMany("PurchaseDetailses")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Test.Model.Sale", b =>
                {
                    b.HasOne("Test.Model.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Test.Model.SaleDetails", b =>
                {
                    b.HasOne("Test.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Test.Model.Sale", "Sale")
                        .WithMany("SaleDetailses")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
