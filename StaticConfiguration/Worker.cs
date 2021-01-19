using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using StaticConfiguration.Configuration;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace StaticConfiguration
{
    internal class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly JsonGroup jsonSettings;
        private readonly EnvGroup envSettings;
        private readonly CmdGroup cmdSettings;

        //IOptions will be read at application start only and wiil be registered as a singleton
        //IOptionsSnapshot will be read everytime a new instance is injected and registered as scoped
        public Worker(ILogger<Worker> logger, IOptions<JsonGroup> jsonOptions,
            IOptions<EnvGroup> envOptions, IOptions<CmdGroup> cmdOptions)
        {
            this.logger = logger;
            jsonSettings = jsonOptions.Value;
            envSettings = envOptions.Value;
            cmdSettings = cmdOptions.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                logger.LogInformation("JsonValue is {value}", jsonSettings.JsonValue);
                logger.LogInformation("EnvValue is {value}", envSettings.EnvValue);
                logger.LogInformation("CmdValue is {value}", cmdSettings.CmdValue);

                await Task.Delay(5000, cancellationToken);
            }
        }
    }
}