using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace ConsolePropertyInjectionSample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .AddSingleton<IConfiguration>(configuration)

                .AddScoped<IStartUp, StartUp>()
                .AddScoped<IService>(provider =>
                {
                    ILogger logger = provider.GetService<ILoggerFactory>().CreateLogger<Service>();
                    IConfiguration config = provider.GetService<IConfiguration>();
                    return new Service { Configuration = config, Logger = logger };
                })
                .BuildServiceProvider();

            ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("You now have access to a complete IServiceProvider (IOC) through variable serviceProvider");

            await serviceProvider
                .GetService<IStartUp>()
                .RunAsync();
        }
    }
}