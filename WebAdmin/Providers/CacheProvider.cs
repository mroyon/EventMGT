using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using System;
using System.Threading.Tasks;


namespace WebAdmin.Providers
{
    /// <summary>
    /// CacheProvider
    /// </summary>
    public class CacheProvider : ICacheProvider
    {

        private readonly IDistributedCache _cache;


        /// <summary>
        /// CacheProvider
        /// </summary>
        /// <param name="redisCacheClient"></param>
        /// <param name="configuration"></param>
        public CacheProvider(
            IDistributedCache cache
            )
        {
            _cache = cache;
        }

        /// <summary>
        /// GetFromCache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string key) where T : class
        {
            var cachedResponse = await _cache.GetStringAsync(key);
            return cachedResponse == null ? null : JsonConvert.DeserializeObject<T>(cachedResponse);
        }

        /// <summary>
        /// SetCache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheLifeTime"></param>
        /// <returns></returns>
        public async Task Set<T>(string key, T value, int? cacheLifeTime = 30) where T : class
        {
            DateTime dtlifespan = DateTime.Now;
            dtlifespan = dtlifespan.AddMinutes(cacheLifeTime.GetValueOrDefault(30));

            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(43200)));
        }

        /// <summary>
        /// GetPrivate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<T> GetPrivate<T>(string key, string userid) where T : class
        {
            key = key + (string.IsNullOrEmpty(userid) == true ? "" : userid);
            var cachedResponse = await _cache.GetStringAsync(key);
            return cachedResponse == null ? null : JsonConvert.DeserializeObject<T>(cachedResponse);
        }

        /// <summary>
        /// SetPrivate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="userid"></param>
        /// <param name="value"></param>
        /// <param name="cacheLifeTime"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SetPrivate<T>(string key, string userid, T value, int? cacheLifeTime = null) where T : class
        {

            DateTime dtlifespan = DateTime.Now;
            dtlifespan = dtlifespan.AddMinutes(cacheLifeTime.GetValueOrDefault(30));
            key = key + (string.IsNullOrEmpty(userid) == true ? "" : userid);
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value),
                new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(43200)));
        }


        /// <summary>
        /// ClearCache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task Remove(string key)
        {
            await _cache.RemoveAsync(key);
        }

    }


}
