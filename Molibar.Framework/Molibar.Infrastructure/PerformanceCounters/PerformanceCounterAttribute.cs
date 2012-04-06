using System;
using System.Diagnostics;

namespace Molibar.Infrastructure.PerformanceCounters
{
    /// <summary>
    /// Defines a performance counter for the class that it is tagged with it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class PerformanceCounterAttribute : Attribute
    {

        string name;
        string help;
        PerformanceCounterType type;


        /// <summary>
        /// Creates a new performance counter attribute with the given counter name.
        /// </summary>
        /// <remarks>
        /// Creates a new performance counter attribute with the given counter name.
        /// </remarks>
        /// <param name="name">Counter name.</param>
        public PerformanceCounterAttribute(string name)
            : this(name, null, PerformanceCounterType.NumberOfItems64)
        {
            // nothing to do
        }

        /// <summary>
        /// Creates a new performance counter attribute with the given counter name and type.
        /// </summary>
        /// <remarks>
        /// Creates a new performance counter attribute with the given counter name and type.
        /// </remarks>
        /// <param name="name">Counter name.</param>
        /// <param name="type">Counter type.</param>
        public PerformanceCounterAttribute(string name, PerformanceCounterType type)
            : this(name, null, type)
        {
            // nothing to do
        }

        /// <summary>
        /// Creates a new performance counter attribute with the given counter name, help and type.
        /// </summary>
        /// <remarks>
        /// Creates a new performance counter attribute with the given counter name, help and type.
        /// </remarks>
        /// <param name="name">Counter name.</param>
        /// <param name="help">Counter help.</param>
        public PerformanceCounterAttribute(string name, string help)
            : this(name, help, PerformanceCounterType.NumberOfItems64)
        {
            // nothing to do
        }

        /// <summary>
        /// Creates a new performance counter attribute with the given counter name, help, member name and type.
        /// </summary>
        /// <remarks>
        /// Creates a new performance counter attribute with the given counter name, help, member name and type.
        /// </remarks>
        /// <param name="name">Counter name.</param>
        /// <param name="help">Counter help.</param>
        /// <param name="type">Counter type.</param>
        public PerformanceCounterAttribute(string name, string help, PerformanceCounterType type)
        {
            this.name = name;
            this.help = help;
            this.type = type;
        }


        /// <summary>
        /// Gets the performance counter name.
        /// </summary>
        /// <remarks>
        /// Gets the performance counter name.
        /// </remarks>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets the performance counter help.
        /// </summary>
        /// <remarks>
        /// Gets the performance counter help.
        /// </remarks>
        public string Help { get { return help; } }

        /// <summary>
        /// Gets the type of the performance counter.
        /// </summary>
        /// <remarks>
        /// Gets the type of the performance counter.
        /// </remarks>
        public PerformanceCounterType Type { get { return type; } }
    }
}