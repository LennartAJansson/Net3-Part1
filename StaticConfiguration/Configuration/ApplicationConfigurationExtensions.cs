using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StaticConfiguration.Configuration
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, HostBuilderContext hostBuilder)
        {
            //To get an instance of a specific setting using ConfigurationBinder:
            //var setting = hostBuilder.Configuration.GetSection(CmdGroupSettings.GroupName).Get<EnvGroupSettings>();

            services.Configure<JsonGroup>(settings =>
                hostBuilder.Configuration.GetSection(JsonGroup.Section).Bind(settings));
            services.Configure<EnvGroup>(settings =>
                hostBuilder.Configuration.GetSection(EnvGroup.Section).Bind(settings));
            services.Configure<CmdGroup>(settings =>
                hostBuilder.Configuration.GetSection(CmdGroup.Section).Bind(settings));

            return services;
        }
    }
}