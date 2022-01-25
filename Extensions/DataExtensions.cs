using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Extensions
{
    public static class DataExtensions
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            
            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                SeedData.Initialize(serviceScope.ServiceProvider);
            }

            return app;
        }
    }
}
