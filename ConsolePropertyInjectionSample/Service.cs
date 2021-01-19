using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace ConsolePropertyInjectionSample
{
    internal class Service : IService
    {
        public ILogger Logger { get; set; }

        public IConfiguration Configuration { get; set; }

        public Task ExecuteAsync()
        {
            Logger.LogInformation("Running Service");
            Logger.LogInformation("Asking for configuration[\"Section: Value\"], result {value}", Configuration["Section:Value"]);
            Logger.LogInformation("Asking for configuration.GetSection(\"Section\")[\"Value\"], result {value}", Configuration.GetSection("Section")["Value"]);

            return Task.CompletedTask;
        }
    }
}