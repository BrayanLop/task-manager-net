using System.Runtime.Caching;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        public bool Exists(string key)
        {
            return _cache.Contains(key);
        }

        public string Get(string key)
        {
            var value = _cache.Get(key);

            return value as string;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, string value)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            };

            _cache.Set(key, value, policy);
        }
    }
}
