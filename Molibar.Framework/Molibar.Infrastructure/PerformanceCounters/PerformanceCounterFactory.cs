using System;
using System.Diagnostics;
using System.Reflection;

namespace Molibar.Infrastructure.PerformanceCounters
{
    /// <summary>
    /// Wrapper and Helper class for a category of performance counters.
    /// </summary>
    /// <remarks>
    /// Wrapper and Helper class for a category of performance counters.
    /// </remarks>
    public class PerformanceCounterFactory
    {
        private CounterCreationDataCollection _counters;

        public string CategoryName { get; private set; }
        public string CategoryHelp { get; private set; }


        /// <summary>
        /// Creates a new category for the specified type.
        /// </summary>
        /// <remarks>
        /// Type must have <c>PerformanceCounterCategoryAttribute</c> and <c>PerformanceCounterAttributes</c> set.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified type has no performance counter category attribute set.
        /// </exception>
        /// <param name="type">Type to create Performance counters for.</param>
        public PerformanceCounterFactory(Type type)
        {
            _counters = new CounterCreationDataCollection();

            var category = GetCategory(type);
            if (category == null) throw new ArgumentException(String.Format("Type {0} has no PerformanceCounterCategory attribute", type.Name), "type");

            CategoryName = category.Name;
            CategoryHelp = category.Help;

            _AddCounters(type);
        }

        /// <summary>
        /// Gets a writable instance of a performance counter in this category.
        /// </summary>
        /// <value>
        /// Writable instance of a performance counter in this category.
        /// </value>
        public PerformanceCounter this[string counterName]
        {
            get { return GetCounter(CategoryName, counterName, false); }
        }

        /// <summary>
        /// Gets the counter creation data collection
        /// </summary>
        /// <remarks>
        /// Can be passed to a PerformanceCounterInstaller.
        /// </remarks>
        public CounterCreationDataCollection Counters
        {
            get { return _counters; }
        }

        
        /// <summary>
        /// Gets an instance of the specified performance counter in this category.
        /// </summary>
        /// <param name="counterName">Performance counter name.</param>
        /// <param name="readOnly">If true, the returned counter is readonly. If false, the returned counter is writable.</param>
        /// <returns>Performance counter instance.</returns>
        public PerformanceCounter GetCounter(string counterName, bool readOnly)
        {
            return GetCounter(CategoryName, counterName, readOnly);
        }

        /// <summary>
        /// Gets a readonly instance of the specified performance counter in this category.
        /// </summary>
        /// <param name="counterName">Performance counter name</param>
        /// <returns></returns>
        public PerformanceCounter GetCounter(string counterName)
        {
            return GetCounter(counterName, false);
        }

        /// <summary>
        /// Adds a performance counter of the given type to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a performance counter of the given type to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="type">Performance counter type.</param>
        /// <param name="help">Performance counter help text.</param>
        public void AddCounter(string name, PerformanceCounterType type, string help)
        {
            var counter = new CounterCreationData
                              {
                                  CounterName = name,
                                  CounterType = type
                              };
            if (help != null)
                counter.CounterHelp = help;

            _counters.Add(counter);
        }

        /// <summary>
        /// Adds a performance counter of the given type to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a performance counter of the given type to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="type">Performance counter type.</param>
        public void AddCounter(string name, PerformanceCounterType type)
        {
            AddCounter(name, type, null);
        }

        /// <summary>
        /// Adds a NumberOfItems64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a NumberOfItems64 performance counter to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="help">Performance counter help text.</param>
        public void AddNumberCounter(string name, string help)
        {
            AddCounter(name, PerformanceCounterType.NumberOfItems64, help);
        }

        /// <summary>
        /// Adds a NumberOfItems64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a NumberOfItems64 performance counter to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        public void AddNumberCounter(string name)
        {
            AddCounter(name, PerformanceCounterType.NumberOfItems64, null);
        }

        /// <summary>
        /// Adds a RateOfCountsPerSecond64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a RateOfCountsPerSecond64 performance counter to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="help">Performance counter help text.</param>
        public void AddRateCounter(string name, string help)
        {
            AddCounter(name, PerformanceCounterType.RateOfCountsPerSecond64, help);
        }

        /// <summary>
        /// Adds a RateOfCountsPerSecond64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Adds a RateOfCountsPerSecond64 performance counter to the category collection.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        public void AddRateCounter(string name)
        {
            AddCounter(name, PerformanceCounterType.RateOfCountsPerSecond64);
        }

        /// <summary>
        /// Adds a AverageCount64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Also adds the required base counter.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="help">Performance counter help text.</param>
        public void AddAverageCounter(string name, string help)
        {
            // add average counter
            AddCounter(name, PerformanceCounterType.AverageCount64, help);
            // add the corresponding base counter
            AddCounter(name + "Base", PerformanceCounterType.AverageBase, null);
        }

        /// <summary>
        /// Adds a AverageCount64 performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Also adds the required base counter.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        public void AddAverageCounter(string name)
        {
            AddAverageCounter(name, null);
        }

        /// <summary>
        /// Adds a RawFraction performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Also adds the required base counter.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        /// <param name="help">Performance counter help text.</param>
        public void AddFractionCounter(string name, string help)
        {
            // add average counter
            AddCounter(name, PerformanceCounterType.RawFraction, help);
            // add the corresponding base counter
            AddCounter(name + "Base", PerformanceCounterType.RawBase, null);
        }

        /// <summary>
        /// Adds a RawFraction performance counter to the category collection.
        /// </summary>
        /// <remarks>
        /// Also adds the required base counter.
        /// </remarks>
        /// <param name="name">Performance counter name.</param>
        public void AddFractionCounter(string name)
        {
            AddFractionCounter(name, null);
        }


        /// <summary>
        /// Adds all performance counter for the specified Type to this category.
        /// </summary>
        /// <remarks>
        /// Performance category name of the Type must match the one of this category instance.
        /// </remarks>
        /// <param name="type">Type</param>
        public void AddCounters(Type type)
        {
            var category = GetCategory(type);
            if (category == null)
                throw new ArgumentException(String.Format("Type {0} has no PerformanceCounterCategory attribute", type.Name), "type");

            if (category.Name != CategoryName)
                throw new ArgumentException("Category names do not match");

            _AddCounters(type);
        }

        /// <summary>
        /// Indicates if the performance counter category exists.
        /// </summary>
        /// <remarks>
        /// Indicates if the performance counter category exists.
        /// </remarks>
        /// <returns>True if it does exist, false otherwise.</returns>
        public bool Exists()
        {
            return Exists(CategoryName);
        }

        /// <summary>
        /// Creates performance counter category and counters.
        /// </summary>
        /// <remarks>
        /// If the category already exists only non existing counters are added.
        /// </remarks>
        public void Create()
        {
            if (!Exists(CategoryName))
            {
                // category does not exist, create
                PerformanceCounterCategory.Create(CategoryName, CategoryHelp, PerformanceCounterCategoryType.SingleInstance, _counters);
            }
        }

        /// <summary>
        /// Deletes the performance counter category and counters.
        /// </summary>
        /// <remarks>
        /// Deletes the performance counter category and counters.
        /// </remarks>
        public void Delete()
        {
            Delete(CategoryName);
        }

        
        private static PerformanceCounterCategoryAttribute GetCategory(Type type)
        {
            // get category attribute
            object[] attributes = type.GetCustomAttributes(typeof(PerformanceCounterCategoryAttribute), true);

            // we don't have performance counter category, give up
            if (attributes.Length < 1) return null;

            return (PerformanceCounterCategoryAttribute)attributes[0];
        }

        private void _AddCounters(Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
            {
                // ignore member if it is not a performance counter
                if (field.FieldType != typeof(PerformanceCounter)) continue;

                // get the performance counter attribute
                var attributes = field.GetCustomAttributes(typeof(PerformanceCounterAttribute), false);
                // ignore it if it has no performance counter attribute set
                if (attributes.Length < 1) continue;

                // assign the performance counter
                var counter = (PerformanceCounterAttribute)attributes[0];
                AddCounter(counter.Name, counter.Type, counter.Help);

                // create base counter if needed
                switch (counter.Type)
                {
                    case PerformanceCounterType.AverageCount64:
                    case PerformanceCounterType.AverageTimer32:
                        AddCounter(counter.Name + "Base", PerformanceCounterType.AverageBase);
                        break;
                    case PerformanceCounterType.RawFraction:
                        AddCounter(counter.Name + "Base", PerformanceCounterType.RawBase);
                        break;
                    case PerformanceCounterType.CounterMultiTimer:
                    case PerformanceCounterType.CounterMultiTimerInverse:
                    case PerformanceCounterType.CounterMultiTimer100Ns:
                    case PerformanceCounterType.CounterMultiTimer100NsInverse:
                        AddCounter(counter.Name + "Base", PerformanceCounterType.CounterMultiBase);
                        break;
                    case PerformanceCounterType.SampleCounter:
                    case PerformanceCounterType.SampleFraction:
                        AddCounter(counter.Name + "Base", PerformanceCounterType.SampleBase);
                        break;
                }
            }
        }

        
        /// <summary>
        /// Gets a performance counter instance for a given name and category.
        /// </summary>
        /// <remarks>
        /// Gets a performance counter instance for a given name and category.
        /// </remarks>
        /// <param name="categoryName">Performance counter category.</param>
        /// <param name="counterName">Performance counter name.</param>
        /// <param name="readOnly">ReadOnly</param>
        /// <returns>Performance counter instance.</returns>
        public static PerformanceCounter GetCounter(string categoryName, string counterName, bool readOnly)
        {
            return new PerformanceCounter(categoryName, counterName, readOnly);
        }

        /// <summary>
        /// Checks if a performance counter category exists.
        /// </summary>
        /// <param name="categoryName">Performance counter category name.</param>
        /// <returns>True if the category exists, false otherwise.</returns>
        public static bool Exists(string categoryName)
        {
            return PerformanceCounterCategory.Exists(categoryName);
        }

        /// <summary>
        /// Deletes the specified performance counter category and counters.
        /// </summary>
        /// <remarks>
        /// Deletes the specified performance counter category and counters.
        /// </remarks>
        /// <param name="categoryName">Performance counter category name.</param>
        public static void Delete(string categoryName)
        {
            PerformanceCounterCategory.Delete(categoryName);
        }

        /// <summary>
        /// Creates instances for all performance counter members in the given type.
        /// </summary>
        /// <remarks>
        /// The type must have the PerformanceCounterCategory attribute set. Each performance counter
        /// member must be static and tagged with a PerformanceCounter attribute.
        /// </remarks>
        /// <param name="type">Type to instantiate counters</param>
        /// <returns><b>True</b> if counters were created successfully, <b>false</b> otherwise.</returns>
        public static bool CreateCounters(Type type)
        {
            return CreateCounters(type, null);
        }

        /// <summary>
        /// Creates instances for all performance counter members in the given type.
        /// </summary>
        /// <remarks>
        /// The type must have the PerformanceCounterCategory attribute set. Each performance counter
        /// member must be static and tagged with a PerformanceCounter attribute.
        /// </remarks>
        /// <param name="type">Type to instantiate counters</param>
        /// <param name="instance">Instance to assign performance counters to.</param>
        /// <returns><b>True</b> if counters were created successfully, <b>false</b> otherwise.</returns>
        public static bool CreateCounters(Type type, object instance)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (instance != null && type != instance.GetType()) throw new ArgumentException("The type must be equal to instance.GetType if instance not null");

            // get category attribute
            var attributes = type.GetCustomAttributes(typeof(PerformanceCounterCategoryAttribute), true);

            // we don't have performance counter category, we are done
            if (attributes.Length < 1) return false;
            var category = (PerformanceCounterCategoryAttribute)attributes[0];

            var result = false;
            try
            {
                if (PerformanceCounterCategory.Exists(category.Name))
                {
                    foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
                    {
                        // ignore member if it is not a performance counter or it is not static
                        if (field.FieldType != typeof(PerformanceCounter) || (instance == null && !field.IsStatic)) continue;

                        // get the performance counter attribute
                        attributes = field.GetCustomAttributes(typeof(PerformanceCounterAttribute), false);
                        // ignore it if it has no performance counter attribute set
                        if (attributes.Length < 1) continue;

                        // assign the performance counter
                        var counter = (PerformanceCounterAttribute)attributes[0];
                        field.SetValue(instance, new PerformanceCounter(category.Name, counter.Name, false));

                        // create base counter if needed
                        switch (counter.Type)
                        {
                            case PerformanceCounterType.AverageCount64:
                            case PerformanceCounterType.RawFraction:
                                FieldInfo baseCounter = type.GetField(field.Name + "Base", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
                                if (baseCounter != null)
                                    baseCounter.SetValue(instance, new PerformanceCounter(category.Name, counter.Name + "Base", false));
                                break;
                        }
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
