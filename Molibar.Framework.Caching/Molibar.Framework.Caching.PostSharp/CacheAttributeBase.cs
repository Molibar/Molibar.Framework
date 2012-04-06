using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using PostSharp.Extensibility;
using PostSharp.Laos;

namespace Molibar.Caching.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class CacheAttributeBase : OnMethodInvocationAspect
    {
        private MethodFormatStrings _formatStrings;

        /// <summary>
        ///   Default value is set to 15 minutes.
        /// </summary>
        public int CacheMinutes { get; set; }

        /// <summary>
        /// Gets or sets a zero-based array specifying parameters to exclude from the signature constituting the key in the cache.
        /// </summary>
        public int[] ExcludedParams { get; set; }

        /// <summary>
        ///   The method that wraps the decorated method.
        ///   This method performs the actual 
        /// </summary>
        /// <param name="eventArgs"></param>
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            InitializeCache();

            var cacheOptions = GetCacheOptions(eventArgs);
            if (cacheOptions != null)
            {
                ExcludeCacheOptionsParam(eventArgs);
            }

            var key = _formatStrings.Format(eventArgs.Instance, eventArgs.Method, GetFilteredArgumentArray(eventArgs));

            if (cacheOptions == CacheOptions.Refresh)
            {
                RemoveFromCache(key);
            }

            // Test whether the cache contains the current method call.
            var value = GetValueFromCacheKey(key, cacheOptions);

            if (value == null)
            {
                eventArgs.Proceed();
                value = eventArgs.ReturnValue;
                AddToCache(key, value, CacheItemPriority.Normal, null, new TimeSpan(0, CacheMinutes, 0), cacheOptions);
            }

            eventArgs.ReturnValue = value;
        }

        public override void CompileTimeInitialize(MethodBase method)
        {
            _formatStrings = Formatter.GetMethodFormatStrings(method);
        }

        /// <summary>
        ///   CompileTimeValidate performs compile check.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public override bool CompileTimeValidate(MethodBase method)
        {
            // Don't apply to constructors.  
            if (method is ConstructorInfo)
            {
                CacheMessageSource.Instance.Write(SeverityType.Error, "CX0001", null);
                return false;
            }
            var methodInfo = (MethodInfo)method;
            // Don't apply to void methods.  
            if (methodInfo != null)
            {
                if (methodInfo.ReturnType != null)
                {
                    if (methodInfo.ReturnType.Name == "Void")
                    {
                        CacheMessageSource.Instance.Write(SeverityType.Error, "CX0002", null);
                        return false;
                    } // Does not support out parameters.
                }
            }
            var parameters = method.GetParameters();
            if (parameters.Any(t => t.IsOut))
            {
                CacheMessageSource.Instance.Write(SeverityType.Error, "CX0003", null);
                return false;
            }
            return true;
        }

        protected abstract void InitializeCache();
        protected abstract void AddToCache(string key, object value, CacheItemPriority normal, object o, TimeSpan timeSpan, CacheOptions? cacheOptions);
        protected abstract object GetValueFromCacheKey(string key, CacheOptions? cacheOptions);
        protected abstract void RemoveFromCache(string key);

        private void ExcludeCacheOptionsParam(MethodInvocationEventArgs eventArgs)
        {
            var index = eventArgs.Method.GetParameters().Length - 1;
            if (ExcludedParams != null && ExcludedParams.Contains(index))
            {
                return;
            }

            ExcludedParams = ExcludedParams != null ? ExcludedParams.Concat(new[] { index }).ToArray() : new[] { index };
        }

        private object[] GetFilteredArgumentArray(MethodInvocationEventArgs e)
        {
            if (ExcludedParams == null)
            {
                return e.GetArgumentArray();
            }

            var args = e.GetArgumentArray();

            // Replace objects at specified indexes in the array with null-value
            return args.Select((arg, index) => ExcludedParams.Contains(index) ? null : arg).ToArray();
        }

        private static CacheOptions? GetCacheOptions(MethodInvocationEventArgs e)
        {
            var args = e.Method.GetParameters();
            if (args.Length == 0)
            {
                return null;
            }

            if (args[args.Length - 1].ParameterType == typeof(CacheOptions))
            {
                return (CacheOptions)e.GetArgumentArray()[args.Length - 1];
            }

            return null;
        }
    }
}