using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace CronSample
{
    internal static class Program
    {
        private static async Task Main(string[] args) => await Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => ConfigureAppServices(services))
                .Build()
                .RunApplication();

        private static IServiceCollection ConfigureAppServices(IServiceCollection services)
        {
            services.AddTransient<IWorker, Worker>();

            return services;
        }
    }
}