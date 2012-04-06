using System;
using System.Runtime.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using CacheItemPriority = Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority;

namespace Molibar.Caching.PostSharp
{
    /// <summary>
    ///   Default minutes to cache is set in the constructor to 15 minutes.
    ///   Setting the CacheMinutes property in the attribute overrides default.
    ///   For info about aspects see postsharp.org
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CacheAttribute : CacheAttributeBase
    {
        public static bool DisabledDueToTesting;
        private const string CacheInvalidatorSessionKey = "CacheStateManager";

        [NonSerialized]
        private ICacheManager _cacheManager;

        public CacheAttribute()
        {
            CacheMinutes = 15;
        }

        protected override void RemoveFromCache(string key)
        {
            var stateManager = GetStateManager();
            stateManager.InvalidateCache(key);
        }

        protected override object GetValueFromCacheKey(string key, CacheOptions? cacheOptions)
        {
            if (DisabledDueToTesting) return null;

            if (cacheOptions != null && IsCacheStale(key))
            {
                return null;
            }

            return _cacheManager.GetData(key);
        }

        protected override void InitializeCache()
        {
            if (DisabledDueToTesting) return;

           _cacheManager = CacheFactory.GetCacheManager();
        }

        protected override void AddToCache(string key, object value, CacheItemPriority normal, object o, TimeSpan timeSpan, CacheOptions? cacheOptions)
        {
            if (DisabledDueToTesting) return;

            _cacheManager.Add(key, value, CacheItemPriority.Normal, null,
                             new AbsoluteTime(timeSpan));

            if (cacheOptions != null && IsCacheStale(key))
            {
                ClearStaleFlag(key);
            }
        }

        private static CacheStateManager GetStateManager()
        {
            var memoryCache = MemoryCache.Default;

            var cacheInvalidator = (CacheStateManager) memoryCache.Get(CacheInvalidatorSessionKey);
            if (cacheInvalidator == null)
            {
                cacheInvalidator = new CacheStateManager();
                memoryCache.Add(CacheInvalidatorSessionKey, cacheInvalidator,
                    new CacheItemPolicy()
                        {
                            AbsoluteExpiration = DateTime.Now.AddSeconds(600)
                        });
            }

            return cacheInvalidator;
        }

        private static bool IsCacheStale(string key)
        {
            var stateManager = GetStateManager();
            var machineName = Environment.MachineName;

            return stateManager.IsCacheStale(key, machineName);
        }

        private static void ClearStaleFlag(string key)
        {
            var stateManager = GetStateManager();
            var machineName = Environment.MachineName;

            stateManager.ClearStaleFlag(key, machineName);
        }
    }
}
