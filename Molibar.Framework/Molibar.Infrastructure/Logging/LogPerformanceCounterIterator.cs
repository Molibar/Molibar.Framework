using System;
using System.Diagnostics;
using Molibar.Infrastructure.PerformanceCounters;
using log4net.Core;

namespace Molibar.Infrastructure.Logging
{
    [Serializable]
    [PerformanceCounterCategory("Molibar.Framework",
        "PerformanceCounters showing events passing the Molibar.Framework")]
    public class LogPerformanceCounterIterator
    {
        [PerformanceCounter("# logged entries / sec", "Number of entries logged per second",
            PerformanceCounterType.RateOfCountsPerSecond32)] private static PerformanceCounter _entriesPerSecond;

        [PerformanceCounter("# logged errors / sec", "Number of errors logged per second",
            PerformanceCounterType.RateOfCountsPerSecond32)] private static PerformanceCounter _errorsPerSecond;

        [PerformanceCounter("# logged exceptions / sec", "Number of exceptions logged per second",
            PerformanceCounterType.RateOfCountsPerSecond32)] private static PerformanceCounter _exceptionsPerSecond;

        private static bool _usePerformanceCounters;



        static LogPerformanceCounterIterator()
        {
            try
            {
                // create writable performance counter instances
                _usePerformanceCounters = PerformanceCounterFactory.CreateCounters(typeof (LogPerformanceCounterIterator), null);
            }
            catch (Exception exception)
            {
                Log.ErrorMessage(typeof (Log), "Unable to create performance counters", exception);
                _usePerformanceCounters = false;
            }
        }


        public void OnEntry(Level level, Exception exception = null)
        {
            if (!_usePerformanceCounters) return;
            try
            {
                _entriesPerSecond.Increment();
                if (level.Value >= Level.Error.Value) _errorsPerSecond.Increment();
                if (exception != null) _exceptionsPerSecond.Increment();
            }
            catch (Exception thrown)
            {
                _usePerformanceCounters = false;
                Log.ErrorMessage(typeof(Log), "Unable to increment performance counters", thrown);
            }
        }
    }
}
