using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinSvcSample
{
    internal static class Program
    {
        private static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices(services => services.AddHostedService<Worker>());
    }
}

/*
According to the code documentation, UseWindowsService() does the following:

Sets the host lifetime to WindowsServiceLifetime
Sets the Content Root
Enables logging to the event log with the application name as the default source name

You can run the Worker Service in various ways:

Build and Debug/Run from within Visual Studio.
Publish to an exe file and run it
Run the sc utility (from Windows\System32) to create a new service
*/