using System.Reflection;
using System.Resources;
using PostSharp.Extensibility;

namespace Molibar.Caching.PostSharp
{
    public class CacheMessageSource
    {
        public static MessageSource Instance =
            new MessageSource("Molibar.Framework.Caching",
                              new ResourceManager("Molibar.Framework.Caching",
                                                  Assembly.GetCallingAssembly()));

    }
}