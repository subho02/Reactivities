using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();            
            using (var scope = host.Services.CreateScope())
            {  
                var sevices = scope.ServiceProvider;              
                try{
                    var context = sevices.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
                catch(Exception ex){
                    var logger = sevices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error has occured during mmigration");
                }
            }
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
