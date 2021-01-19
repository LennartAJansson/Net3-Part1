using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using MonitoredConfiguration.Configuration;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MonitoredConfiguration
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private JsonGroup jsonSettings;
        private readonly EnvGroup envSettings;
        private readonly CmdGroup cmdSettings;

        public Worker(ILogger<Worker> logger, IOptionsMonitor<JsonGroup> jsonOptions,
            IOptions<EnvGroup> envOptions, IOptions<CmdGroup> cmdOptions)
        {
            this.logger = logger;
            jsonSettings = jsonOptions.CurrentValue;
            jsonOptions.OnChange(newValue => jsonSettings = newValue);
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