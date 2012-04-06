using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Molibar.Infrastructure.PerformanceCounters
{
    public class TimeMeasurer
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private static long _frequency;

        // Decimal instead of double since double
        // can't present decimals exactly.
        private readonly Decimal _multiplier = new Decimal(1.0e9);

        private long _start;
        private long _stop;

        internal TimeMeasurer(long start, long stop, long frequency)
        {
            _start = start;
            _stop = stop;
            _frequency = frequency;
        }

        public TimeMeasurer()
        {
            if (_frequency != 0L) return;
            var frequency = 0L;
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
            _frequency = frequency;
        }

        public void Start()
        {
            QueryPerformanceCounter(out _start);
        }

        public void Stop()
        {
            QueryPerformanceCounter(out _stop);
        }

        public double Nanoseconds
        {
            get { return ((_stop - _start)*(double) _multiplier)/_frequency; }
        }

        public TimeSpan TimeSpan
        {
            get
            {
                return new TimeSpan((long)(Nanoseconds / 100));
            }
        }
    }
}