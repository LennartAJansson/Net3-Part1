using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace ConsoleSample
{
    internal class StartUp : IStartUp
    {
        private readonly ILogger<StartUp> logger;
        private readonly IService service;

        public StartUp(ILogger<StartUp> logger, IService service)
        {
            this.logger = logger;
            this.service = service;
        }

        public async Task RunAsync()
        {
            logger.LogInformation("Running Startup");
            await service.ExecuteAsync();
        }
    }
}