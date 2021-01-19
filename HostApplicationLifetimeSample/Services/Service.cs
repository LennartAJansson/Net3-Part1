using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace HostApplicationLifetimeSample.Services
{
    public class Service : IService
    {
        private readonly ILogger<Service> logger;
        private readonly IHostApplicationLifetime hostApplicationLifeTime;
        private readonly IFilter filter;

        public Service(ILogger<Service> logger, IHostApplicationLifetime hostApplicationLifeTime, IFilter filter)
        {
            this.logger = logger;
            this.hostApplicationLifeTime = hostApplicationLifeTime;
            this.filter = filter;
        }

        public async Task RunServiceAsync()
        {
            while (!hostApplicationLifeTime.ApplicationStopping.IsCancellationRequested)
            {
                //do the work
                //Assume we use the filter to select partial data or something
                await filter.SelectAsync();
                logger.LogInformation("Service running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, hostApplicationLifeTime.ApplicationStopping);
            }
        }
    }
}