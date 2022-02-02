using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // seeding data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, InventoryName = "Gas Engine", Quantity = 1, Price = 1000 },
                new Inventory { InventoryId = 2, InventoryName = "Body", Quantity = 1, Price = 400 },
                new Inventory { InventoryId = 3, InventoryName = "Wheel", Quantity = 4, Price = 100 },
                new Inventory { InventoryId = 4, InventoryName = "Seat", Quantity = 5, Price = 50 },
                new Inventory { InventoryId = 5, InventoryName = "Electric Engine", Quantity = 1, Price = 8000 },
                new Inventory { InventoryId = 6, InventoryName = "Battery", Quantity = 5, Price = 500 }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { ProductId = 1, ProductName = "Gas Car", Quantity = 1, Price = 20000 },
               new Product { ProductId = 2, ProductName = "Electric Car", Quantity = 1, Price = 15000 },
               new Product { ProductId = 3, ProductName = "Wheel", Quantity = 4, Price = 100 },
               new Product { ProductId = 4, ProductName = "Seat", Quantity = 5, Price = 50 }
               );
        }
    }
}
