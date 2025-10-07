using Microsoft.Extensions.Configuration;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    internal class SettingsRepository : IConfigurationInterface
    {
        private IConfiguration _configuration { get; set; }
        public SettingsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key)
        {
            return _configuration.Getv(key);
        }
    }
}
