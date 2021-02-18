using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eForm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory.ToString();

            var configurationBuilder = new ConfigurationBuilder().SetBasePath(path);
            configurationBuilder = configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.AddEnvironmentVariables().Build();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>();
        }
}
