using System.Diagnostics;

namespace Molibar.Infrastructure.PerformanceCounters
{
    public class PerformanceCounterUtils
    {
        public static void CreatePerformanceCounter(string categoryName, string categoryHelp,
            CounterCreationDataCollection counterCreationDataCollection)
        {
            if (!PerformanceCounterCategory.Exists(categoryName))
            {   
                // create new category with the counters above
                PerformanceCounterCategory.
                    Create(categoryName, categoryHelp,
                           PerformanceCounterCategoryType.SingleInstance,
                           counterCreationDataCollection);
            }
        }
    }
}
