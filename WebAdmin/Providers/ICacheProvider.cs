using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Providers
{
    /// <summary>
    /// ICacheProvider
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> Get<T>(string key) where T : class;


        /// <summary>
        /// Set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheLifeTime"></param>
        /// <returns></returns>
        Task Set<T>(string key, T value, int? cacheLifeTime = null) where T : class;


        /// <summary>
        /// GetPrivate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<T> GetPrivate<T>(string key, string userid) where T : class;


        /// <summary>
        /// SetPrivate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="userid"></param>
        /// <param name="value"></param>
        /// <param name="cacheLifeTime"></param>
        /// <returns></returns>
        Task SetPrivate<T>(string key, string userid, T value, int? cacheLifeTime = null) where T : class;



        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task Remove(string key);
    }
}
