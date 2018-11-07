using System.Collections.Generic;
using IdeaGoal.Domain.Services.Utilities;

namespace IdeaGoal.Domain.UnitTests.Mock.Services
{
    class CacheServiceMock : ICacheService
    {
        private readonly Dictionary<string, object> _cache = new Dictionary<string, object>();

        public T Get<T>(string key)
        {
            return (T)_cache[key];
        }

        public bool TryGetValue<T>(string key, out T item)
        {
            object temp;
            var result = _cache.TryGetValue(key, out temp);

            if (result)
            {
                item = (T)temp;
            }
            else
            {
                item = default(T);
            }

            return result;
        }

        public void Set<T>(string key, T item)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key] = item;
            }
            else
            {
                _cache.Add(key, item);
            }
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
