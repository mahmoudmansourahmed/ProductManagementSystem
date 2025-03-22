using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Unit> Units { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Units)
                .WithMany(q => q.Products)
                .HasForeignKey(p => p.QuantityPerUnitId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, UnitName = "Kilo" },
                new Unit { Id = 2, UnitName = "Box" },
                new Unit { Id = 3, UnitName = "Can" },
                new Unit { Id = 4, UnitName = "Liter" },
                new Unit { Id = 5, UnitName = "Bottle" }
            );

            //بيانات تجريبية
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, SupplierName = "Supplier A" },
                new Supplier { Id = 2, SupplierName = "Supplier B" }
            );
        }
    }
}
