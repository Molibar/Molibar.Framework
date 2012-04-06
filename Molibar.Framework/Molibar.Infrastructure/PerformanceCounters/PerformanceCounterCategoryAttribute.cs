using System;

namespace Molibar.Infrastructure.PerformanceCounters
{
    /// <summary>
    /// Attribute to tag the performance counters for a given class to a performance counter category.
    /// </summary>
    /// <remarks>
    /// Attribute to tag the performance counters for a given class to a performance counter category.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PerformanceCounterCategoryAttribute : Attribute
    {
        private string name;
        private string help;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// Constructor
        /// </remarks>
        /// <param name="name">Performance counter category name.</param>
        public PerformanceCounterCategoryAttribute(string name)
            : this(name, null)
        {
            // nothing to do
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// Constructor
        /// </remarks>
        /// <param name="name">Performance counter category name.</param>
        /// <param name="help">Performance counter category help.</param>
        public PerformanceCounterCategoryAttribute(string name, string help)
        {
            this.name = name;
            this.help = help;
        }

        /// <summary>
        /// Gets the performance counter category.
        /// </summary>
        /// <remarks>
        /// Gets the performance counter category.
        /// </remarks>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the performance counter category help.
        /// </summary>
        /// <remarks>
        /// Gets the performance counter category help.
        /// </remarks>
        public string Help
        {
            get { return help; }
        }
    }
}