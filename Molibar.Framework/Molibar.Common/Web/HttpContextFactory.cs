using System;
using System.Web;

namespace Molibar.Common.Web
{
    public interface IHttpContextFactory
    {
        HttpContextBase Create();
    }

    public class HttpContextFactory : IHttpContextFactory
    {
        public HttpContextBase Context { get; set; }

        public HttpContextBase Create()
        {
            if (Context != null)
                return Context;
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext is not available");
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
}