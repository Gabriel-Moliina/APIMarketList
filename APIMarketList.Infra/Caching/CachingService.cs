using APIMarketList.Domain.Interface.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections;
using System.Text.Json;

namespace APIMarketList.Infra.Data.Caching
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };
        }
        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, _options);
        }

        public async Task<T?> GetOrCreate<T>(string key, Func<Task<T>> function)
        {
            string cachingShopplingList = await GetAsync(key);
            if (!string.IsNullOrEmpty(cachingShopplingList))
                return JsonSerializer.Deserialize<T>(cachingShopplingList);

            var response = await function();

            if (response is not null && response is IEnumerable enumerable && enumerable.Cast<object>().Any())
                await SetAsync(key, JsonSerializer.Serialize(response));

            return response;
        }
    }
}
