using Microsoft.Extensions.Caching.Memory;

namespace IdeaGoal.Domain.Services.Utilities
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public bool TryGetValue<T>(string key, out T item)
        {
            return _memoryCache.TryGetValue(key, out item);
        }

        public void Set<T>(string key, T item)
        {
            _memoryCache.Set(key, item);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
