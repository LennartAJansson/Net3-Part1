using HostApplicationLifetimeSample.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostApplicationLifetimeSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IHostApplicationLifetime hostApplicationLifeTime;
        private readonly IService service;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifeTime, IService service)
        {
            this.logger = logger;
            this.hostApplicationLifeTime = hostApplicationLifeTime;
            this.service = service;
            this.hostApplicationLifeTime.ApplicationStarted.Register(ApplicationStarted);
            this.hostApplicationLifeTime.ApplicationStopped.Register(ApplicationStopped);
            this.hostApplicationLifeTime.ApplicationStopping.Register(ApplicationStopping);
        }

        private void ApplicationStopped()
        {
            logger.LogInformation("ApplicationStopped at: {time}", DateTimeOffset.Now);
        }

        private void ApplicationStopping()
        {
            logger.LogInformation("ApplicationStopping at: {time}", DateTimeOffset.Now);
        }

        private void ApplicationStarted()
        {
            logger.LogInformation("ApplicationStarted at: {time}", DateTimeOffset.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await service.RunServiceAsync();
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, cancellationToken);
            }
        }
    }
}