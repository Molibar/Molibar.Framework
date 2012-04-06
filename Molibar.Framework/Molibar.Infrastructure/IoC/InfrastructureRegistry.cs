using Molibar.Infrastructure.Logging;
using StructureMap.Configuration.DSL;

namespace Molibar.Infrastructure.IoC
{
    public class FrameworkRegistry : Registry
    {
        public FrameworkRegistry(string applicationName = "Anonymous App")
        {
            Log.ApplicationName = applicationName;
            log4net.Config.XmlConfigurator.Configure();
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}