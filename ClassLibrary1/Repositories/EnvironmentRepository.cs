using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class EnviromentRepository : IConfigurationInterface
    {
        public string GetValue(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? string.Empty;
        }
    }
}
