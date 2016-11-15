using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("StoreAPBData")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 
    
        public DbSet<Product> Product { get; set; }
        public DbSet<Electrical_Appliance> Electrical_Appliance { get; set; }
        public DbSet<Meat> Meat { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }   
}