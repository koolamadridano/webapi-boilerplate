using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_boilerplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CREATE LOGGER
            CreateSerilog();
            try
            {
                Log.Information("Application starting");
                // RUN APP
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void CreateSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(
                                path: "D:\\Development\\Logs\\webapi-boilerplate\\log-.txt",
                                outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level: u3}] {Message:lj}{NewLine}{Exception}",
                                rollingInterval: RollingInterval.Day,
                                restrictedToMinimumLevel: LogEventLevel.Information
                            ).CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
