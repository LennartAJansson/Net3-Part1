using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace ConsoleSample
{
    internal class Service : IService
    {
        private readonly ILogger<Service> logger;
        private readonly IConfiguration configuration;

        public Service(ILogger<Service> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public Task ExecuteAsync()
        {
            logger.LogInformation("Running Service");
            logger.LogInformation("Asking for configuration[\"Section: Value\"], result {value}", configuration["Section:Value"]);
            logger.LogInformation("Asking for configuration.GetSection(\"Section\")[\"Value\"], result {value}", configuration.GetSection("Section")["Value"]);

            return Task.CompletedTask;
        }
    }
}