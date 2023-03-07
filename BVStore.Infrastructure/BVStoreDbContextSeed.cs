using BVStore.Domain.Entities;
using BVStore.Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVStore.Infrastructure
{
    public static class BVStoreDbContextSeed
    {
        public static async Task SeedAsync(BVStoreDbContext context, ILogger<BVStoreDbContext> logger)
        {
            SeedCustomers(context);
            SeedProducts(context);

            await context.SaveChangesAsync();

            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(BVStoreDbContext).Name);
        }


        private static void SeedProducts(BVStoreDbContext context)
        {
            if (!context.Products!.Any())
            {
                context.Products!.Add(new Product()
                { Name = "Code complete", Price = 16.66m, ProductType = ProductType.Physical });
                context.Products!.Add(new Product()
                { Name = "Programming Pearls", Price = 16.90m, ProductType = ProductType.Physical });
                context.Products!.Add(new Product()
                { Name = "Building Strange Applications in 3 steps", Price = 13.30m, ProductType = ProductType.Online });
                context.Products!.Add(new Product()
                { Name = "Book club Membership", Price = 15.00m, ProductType = ProductType.BookMembership });
                context.Products!.Add(new Product()
                { Name = "Premium club Membership", Price = 25.00m, ProductType = ProductType.PremiumMembership });
                context.Products!.Add(new Product()
                { Name = "Video club Membership", Price = 15.00m, ProductType = ProductType.VideoMembership });
            }
        }

        private static void SeedCustomers(BVStoreDbContext context)
        {
            if (!context.Customers!.Any())
            {
                context.Customers!.Add(new Customer() { Address = "34 Street", City = "London", Country = "England", MembershipType = MembershipType.None, Name = "John Smith", Phone = "344-55-66-77", PostalCode = "101010", Region = "Western" });
                context.Customers!.Add(new Customer() { Address = "Ruzha Street 3333", City = "Varna", Country = "Bulgaria", MembershipType = MembershipType.None, Name = "Bogdan Bekyarov", Phone = "359-888-88-66-55", PostalCode = "9010", Region = "Varna" });
            }
        }
    }
}
