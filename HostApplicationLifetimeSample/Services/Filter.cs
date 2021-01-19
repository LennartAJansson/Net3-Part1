using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace HostApplicationLifetimeSample.Services
{
    public class Filter : IFilter
    {
        private readonly ILogger<Filter> logger;
        private readonly IHostApplicationLifetime hostApplicationLifeTime;

        public Filter(ILogger<Filter> logger, IHostApplicationLifetime hostApplicationLifeTime)
        {
            this.logger = logger;
            this.hostApplicationLifeTime = hostApplicationLifeTime;
        }

        public async Task SelectAsync()
        {
            while (!hostApplicationLifeTime.ApplicationStopping.IsCancellationRequested)
            {
                //do the work
                logger.LogInformation("Filter running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, hostApplicationLifeTime.ApplicationStopping);
            }
        }
    }
}