using StructureMap.Configuration.DSL;

namespace Molibar.Infrastructure.IoC.StructureMap
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
