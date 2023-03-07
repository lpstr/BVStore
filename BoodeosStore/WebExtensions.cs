using BVStore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BVStore.API
    
{
    public static class WebApplicationExtensions
    {
        public static void MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BVStoreDbContext>();

            context.Database.Migrate();
        }

        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BVStoreDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BVStoreDbContext>>();

            BVStoreDbContextSeed.SeedAsync(context, logger).Wait();
        }
    }
}
