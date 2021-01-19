using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace IHostedServiceSample
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("StartAsync at: {time}", DateTimeOffset.Now);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("StopAsync at: {time}", DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}