using System;
using System.Web;

namespace Molibar.Common.Web
{
    public class CookieUtils
    {
        public static void StoreInCookie(string key, string value, HttpResponseBase response)
        {
            StoreInCookie(key, value, response, new TimeSpan(30, 0, 0));
        }

        public static void StoreInCookie(string key, string value, HttpResponseBase response, TimeSpan timeUntilExpiry)
        {
            if (value == null)
            {
                response.Cookies.Remove(key);
                return;
            }
            var httpCookie = new HttpCookie(key)
                                 {
                                     Value = value,
                                     Expires = DateTime.Now.Add(timeUntilExpiry)
                                 };
            response.Cookies.Add(httpCookie);
        }

        public static string GetFromCookie(string key, HttpRequestBase request)
        {
            var returnCookie = request.Cookies.Get(key);
            return returnCookie == null ? null : returnCookie.Value;
        }
    }
}
