using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace CronSample
{
    public static class ApplicationExtensions
    {
        public static async Task RunApplicationAsync(this IHost host)
        {
            await host.StartAsync();

            IWorker folderService = host.Services.GetRequiredService<IWorker>();

            await folderService.RunAsync();

            using (host)
            {
                await host.StopAsync();
            }
        }
    }
}