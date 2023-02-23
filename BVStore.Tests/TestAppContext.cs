
using BVStore.Domain.Entities;
using BVStore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BVStore.Tests
{
    public class TestStoreAppContext : BVStoreDbContext
    {
        public TestStoreAppContext()
        {
           // this.Products = new TestProductDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Product item) { }
        public void Dispose() { }
    }
}