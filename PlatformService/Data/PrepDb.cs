using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation (IApplicationBuilder App)
        {
                using (var serviceScope = App.ApplicationServices.CreateScope())
                {
                    SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()); 
                }
        }

          private static void SeedData(AppDbContext context)
                {
                        if(!context.Platforms.Any())
                        {
                            Console.WriteLine($"-->Seeding data");
                            context.Platforms.AddRange( 
                                new Platform() {    Name = "Dot Net", Publisher ="Microsoft",Cost = "free" },
                             new Platform(){ Name="Sql Server Express", Publisher="Microsoft", Cost ="Free"},
                               new Platform(){ Name="Kubernetes", Publisher="Cloud Native Computins Foundation", Cost ="free"}
                            );

                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("--> we already have data");
                        }
                }

    }
}