using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BVStore.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace BVStore.Infrastructure
{
    public class BVStoreDbContext : DbContext
    {
        public BVStoreDbContext(DbContextOptions<BVStoreDbContext> options) : base(options)
        {

        }

        public BVStoreDbContext() { }
        //public DbSet<Membership> Memberships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProduct{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<OrderProduct>().HasKey(m => new { m.OrderId, m.ProductId });
            modelBuilder.Entity<Order>().Navigation(e => e.Products).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(e => e.Customer).AutoInclude();
        }
    }
}
