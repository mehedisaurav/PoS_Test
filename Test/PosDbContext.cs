using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using Test.Model;

namespace Repository
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
        {
            
        }

      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetailses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailses { get; set; }   


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category 
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Status).IsRequired();

            //Product
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnitMeasurement).IsRequired();


            //Sale
            modelBuilder.Entity<Sale>().HasKey(s => s.SaleId);
            modelBuilder.Entity<Sale>().Property(s => s.NoOfItem).IsRequired();
            modelBuilder.Entity<Sale>().Property(s => s.TotalAmount).IsRequired();
            modelBuilder.Entity<Sale>().HasOne(x => x.Customer).WithMany(p => p.Sales).HasForeignKey(k => k.CustomerId);

            //SaleDetails
            modelBuilder.Entity<SaleDetails>().HasKey(s => s.SaleDetailsId);
            modelBuilder.Entity<SaleDetails>().Property(s => s.MeasureType).IsRequired();
            modelBuilder.Entity<SaleDetails>().Property(s => s.Quantity).IsRequired();
            modelBuilder.Entity<SaleDetails>().Property(s => s.Price).IsRequired();
            modelBuilder.Entity<SaleDetails>().HasOne(s => s.Sale).WithMany(s => s.SaleDetailses)
                .HasForeignKey(f => f.SaleId).IsRequired();
            modelBuilder.Entity<SaleDetails>().Property(s => s.ProductId).IsRequired();


            //Purchase
            modelBuilder.Entity<Purchase>().HasKey(p => p.PurchaseId);
            modelBuilder.Entity<Purchase>().Property(p => p.NoOfItem).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.TotalAmount).IsRequired();
            modelBuilder.Entity<Purchase>().HasOne(x => x.Supplier).WithMany(p=>p.Purchases).HasForeignKey(k => k.SupplierId);

            //PurchaseDetails
            modelBuilder.Entity<PurchaseDetails>().HasKey(p => p.PurchaseDetailsId);
            modelBuilder.Entity<PurchaseDetails>().Property(p => p.MeasureType).IsRequired();
            modelBuilder.Entity<PurchaseDetails>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<PurchaseDetails>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<PurchaseDetails>().HasOne(p => p.Purchase).WithMany(p => p.PurchaseDetailses)
                .HasForeignKey(f => f.PurchaseId).IsRequired();
            modelBuilder.Entity<PurchaseDetails>().Property(p => p.ProductId).IsRequired();



            //Supplier
            modelBuilder.Entity<Supplier>().HasKey(p => p.SupplierId);
            modelBuilder.Entity<Supplier>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.Phone).IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.Address).HasMaxLength(50).IsRequired();


            //Customer
            modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.Phone).IsRequired();
            

            // add your own confguration here
        }



    }
}
