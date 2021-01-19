using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace CronSample
{
    internal static class Program
    {
        private static async Task Main(string[] args) => await CreateHostBuilder(args).Build().RunApplicationAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddTransient<IWorker, Worker>());
    }
}