using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MonitoredConfiguration.Configuration;

namespace MonitoredConfiguration
{
    internal static class Program
    {
        private static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services.AddApplicationConfiguration(hostContext).AddHostedService<Worker>());
    }
}