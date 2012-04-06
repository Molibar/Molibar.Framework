using System;
using System.ComponentModel;
using System.Reflection;
using Molibar.Infrastructure.PerformanceCounters;

namespace Molibar.Infrastructure
{
    [RunInstaller(true)]
    public partial class PerformanceCounterInstaller : System.Configuration.Install.Installer
    {
        private static System.Diagnostics.PerformanceCounterInstaller _counterInstaller;

        public PerformanceCounterInstaller()
        {
            // This call is required by the Designer.
            InitializeComponent();
            this.Installers.AddRange(new System.Configuration.Install.Installer[]
                                         {
                                             CreateInstaller(this.GetType().Assembly)
                                         });
        }

        public static System.Diagnostics.PerformanceCounterInstaller CreateInstaller(Assembly objAssembly)
        {
            if (objAssembly == null)
                throw new ArgumentNullException("objAssembly");

            _counterInstaller = new System.Diagnostics.PerformanceCounterInstaller();
            foreach (Type objType in objAssembly.GetTypes())
            {
                object[] objCategoryAttriutes = objType.GetCustomAttributes(typeof(PerformanceCounterCategoryAttribute), true);
                if (objCategoryAttriutes.Length > 0)
                {
                    var category = new PerformanceCounterFactory(objType);
                    _counterInstaller.CategoryName = category.CategoryName;
                    if (category.CategoryHelp != null)
                        _counterInstaller.CategoryHelp = category.CategoryHelp;
                    _counterInstaller.Counters.AddRange(category.Counters);
                }
            }
            return _counterInstaller;
        }
    }
}
