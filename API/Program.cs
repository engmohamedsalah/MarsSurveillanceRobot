using System;
using Application.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OBS Test");
            if (args.Length >= 2)
            {
                ProgramForConsole.Run(args);
            }
            else
                CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.AddEnvironmentVariables();

                if (args.Length > 0)
                {
                    configuration.AddCommandLine(args);
                }
            })
            .ConfigureLogging((hostingContext, config) =>
            {
                config.ClearProviders();
                config.AddConsole();
                config.AddDebug();
                config.AddEventSourceLogger();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}