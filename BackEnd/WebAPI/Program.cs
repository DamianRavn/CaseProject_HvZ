using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Creating host
            var host = CreateHostBuilder(args).Build();
            //Getting the service scope
            var service = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            //Using the service to make sure the app migrates
            using(var db = service.CreateScope().ServiceProvider.GetService<HumanVZombiesDbContext>())
            {
                db.Database.Migrate();
            }
                
            //Make sure the host runs
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
