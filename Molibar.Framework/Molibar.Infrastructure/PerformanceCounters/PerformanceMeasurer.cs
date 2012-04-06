using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molibar.Infrastructure.PerformanceCounters
{
    public class PerformanceMeasurer
    {
        private readonly Dictionary<string, List<TimeMeasurer>> _counters = new Dictionary<string, List<TimeMeasurer>>();
        
        public int Count
        {
            get { return _counters.Count; }
        }

        public void Clear()
        {
            _counters.Clear();
        }

        public void StartCounter(string name)
        {
            var list = _counters[name];
            if (list == null)
            {
                list = new List<TimeMeasurer>();
                _counters[name] = list;
            }

            var measurer = new TimeMeasurer();
            list.Add(measurer);
            measurer.Start();
        }


        public double StopCounter(string name)
        {
            var lastTimeSpan = GetLastEntry(name);
            lastTimeSpan.Stop();
            return lastTimeSpan.Nanoseconds;
        }

        public TimeSpan GetTimeSpan(string name)
        {
            return GetLastEntry(name).TimeSpan;
        }

        public double GetNanoseconds(string name)
        {
            return GetLastEntry(name).Nanoseconds;
        }

        private TimeMeasurer GetLastEntry(string name)
        {
            var list = (IList<TimeMeasurer>)_counters[name];
            return list[list.Count - 1];
        }

        public TimeSpan GetLastTimeSpan(string name)
        {
            return GetLastEntry(name).TimeSpan;
        }

        public double GetTotalTimeSpan(string name)
        {
            var list = (IList<TimeMeasurer>) _counters[name];
            return list.Where(timer => timer.Nanoseconds >= 0).Sum(timer => timer.Nanoseconds);
        }

        public double GetAverageTimeInNanoseconds(string name)
        {
            var list = (IList<TimeMeasurer>) _counters[name];
            var total = 0D;
            var counter = 0;
            foreach (var timer in list)
            {
                total += timer.Nanoseconds;
                counter++;
            }
            return (counter > 0) ? total / counter : 0D;
        }

        public double GetMinTimeInNanoseconds(string name)
        {
            var list = (IList<TimeMeasurer>)_counters[name];
            return list.Where(x => x.Nanoseconds >= 0).Min(x => x.Nanoseconds);
        }

        public double GetMaxTimeInNanoseconds(string name)
        {
            var list = (IList<TimeMeasurer>)_counters[name];
            return list.Max(x => x.Nanoseconds);
        }

        public int GetSampleCount(string name)
        {
            var list = (IList<TimeMeasurer>) _counters[name];
            return list.Count(timeSpan => timeSpan.Nanoseconds >= 0);
        }

        public string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Environment.NewLine);
            foreach (var key in _counters.Keys)
            {
                sb.AppendFormat("-- {0} --", key).Append(Environment.NewLine);
                sb.Append("Total Time: ").Append(GetTotalTimeSpan(key)).Append(Environment.NewLine);
                sb.Append("Average Time: ").Append(GetAverageTimeInNanoseconds(key)).Append(Environment.NewLine);
                sb.Append("Max Time: ").Append(GetMaxTimeInNanoseconds(key)).Append(Environment.NewLine);
                sb.Append("Min Time: ").Append(GetMinTimeInNanoseconds(key)).Append(Environment.NewLine);
                sb.Append("Total Count: ").Append(GetSampleCount(key)).Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}