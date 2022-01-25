using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                // Look for any platform.
                context.Database.EnsureCreated();
                if (!context.Platforms.Any())
                {
                    context.Platforms.AddRange(
                       new Platform
                       {
                           Name = ".NET 6",

                       },

                       new Platform
                       {
                           Name = "Angular",

                       },

                       new Platform
                       {
                           Name = "Linux",

                       },

                       new Platform
                       {
                           Name = "Windows",
                           LicenseKey = "25898985998445"

                       }
                    );
                }


                context.SaveChanges();
            }
        }
    }
}
