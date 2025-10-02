using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IConfigurationInterface, SettingsRepository>();
            services.AddScoped<ICacheRepository, CacheRepository>();

            #endregion Repositories

            return services;
        }
    }
}
