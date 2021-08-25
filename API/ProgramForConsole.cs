using System;
using Application.Commands;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API
{
    public class ProgramForConsole
    {
        public static void Run(string[] args)
        {
            //setup our DI

            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .AddScoped<ICommandFactory, CommandFactory>()
             .AddScoped<IBackOffStrategiesService, BackOffStrategiesService>()
             .AddScoped<ILogger<RobotService>, Logger<RobotService>>()
             .AddScoped<IRobotService, RobotService>()
             .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .AddFile("Logs/Console/log-{Date}.txt")
                .CreateLogger<ProgramForConsole>();

            logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>Starting application<<<<<<<<<<<<<<<<<<<<<");

            //do the actual work here
            var robotService = serviceProvider.GetService<IRobotService>();
            //bar.ParseFile(args[0], args[1]);

            try
            {
                robotService.ParseFile(args[0], args[1]);
                var msg = $"output file was saved at {args[1]}";
                Console.WriteLine(msg);
                logger.LogInformation(msg);
                logger.LogInformation("All done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.LogError(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to close");
                Console.ReadLine();
            }
        }
    }
}