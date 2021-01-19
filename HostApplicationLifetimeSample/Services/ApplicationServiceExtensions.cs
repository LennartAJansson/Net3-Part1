using Microsoft.Extensions.DependencyInjection;

namespace HostApplicationLifetimeSample.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IService, Service>();
            services.AddTransient<IFilter, Filter>();

            return services;
        }
    }
}