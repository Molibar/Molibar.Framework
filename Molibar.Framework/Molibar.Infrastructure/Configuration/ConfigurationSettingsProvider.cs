using System;
using System.Reflection;
using Molibar.Infrastructure.Logging;

namespace Molibar.Infrastructure.Configuration
{
    public class ConfigurationSettingsProvider : IConfigurationSettingsProvider
    {
        private readonly IConfigurationSettingsRepository _configurationSettingsRepository;
        private readonly ILogger _logger;
        private object populateSettingsLock = new object();

        public ConfigurationSettingsProvider(IConfigurationSettingsRepository configurationSettingsRepository,
            ILogger logger)
        {
            if (configurationSettingsRepository == null)
                throw new ArgumentNullException("configurationSettingsRepository");
            if (logger == null)
                throw new ArgumentNullException("logger");
            _configurationSettingsRepository = configurationSettingsRepository;
            _logger = logger;
        }

        public void PopulateSettings(ConfigurationPropertyHolder instance)
        {
            lock (populateSettingsLock)
            {
                var settings = _configurationSettingsRepository.GetConfigurationSettingsDictionary(instance.Context);
                var propertyInfos = instance.GetType()
                    .GetProperties(BindingFlags.Instance
                                   | BindingFlags.Public
                                   | BindingFlags.SetProperty);
                foreach (var propertyInfo in propertyInfos)
                {
                    if (settings.ContainsKey(propertyInfo.Name))
                    {
                        SetProperty(propertyInfo, instance, settings[propertyInfo.Name].Value);
                    }
                }
            }
        }


        internal void SetProperty(PropertyInfo propertyInfo, object target, object value)
        {
            switch (propertyInfo.PropertyType.Name)
            {
                case "Int16":
                    propertyInfo.SetValue(target, Convert.ToInt16(value), null);
                    break;
                case "Int32":
                    propertyInfo.SetValue(target, Convert.ToInt32(value), null);
                    break;
                case "Int64":
                    propertyInfo.SetValue(target, Convert.ToInt64(value), null);
                    break;
                case "String":
                    propertyInfo.SetValue(target, value.ToString(), null);
                    break;
                case "Decimal":
                    propertyInfo.SetValue(target, Convert.ToDecimal(value), null);
                    break;
                case "Double":
                    propertyInfo.SetValue(target, Convert.ToDouble(value), null);
                    break;
                case "Boolean":
                    propertyInfo.SetValue(target, Convert.ToBoolean(value), null);
                    break;
                default:
                    _logger.LogErrorMessage(this.GetType(), string.Format("Can't convert {0} to {1} for property {2}.{3}", value, propertyInfo.PropertyType.Name, target.GetType().FullName, propertyInfo.Name));
                    return;
            }
        }
    }
}
