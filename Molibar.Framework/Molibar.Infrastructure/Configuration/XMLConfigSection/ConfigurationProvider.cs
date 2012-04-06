using System;
using System.Configuration;

namespace Molibar.Infrastructure.Configuration.XMLConfigSection
{
    #region Directives

    

    #endregion

    /// <summary>
    /// The configuration provider.
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        #region Constants and Fields

        /// <summary>
        ///   The config file path.
        /// </summary>
        private static string configFilePath;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <typeparam name="TConfig">
        /// The type of the config.
        /// </typeparam>
        /// <returns>
        /// The configuration section
        /// </returns>
        public TConfig GetConfiguration<TConfig>()
        {
            return !string.IsNullOrEmpty(configFilePath)
                       ? GetConfiguration<TConfig>(configFilePath, typeof(TConfig).Name)
                       : GetConfiguration<TConfig>(typeof(TConfig).Name);
        }

        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <typeparam name="TConfig">
        /// The type of the config.
        /// </typeparam>
        /// <param name="sectionName">
        /// The section name.
        /// </param>
        /// <returns>
        /// The configuration section
        /// </returns>
        public TConfig GetConfiguration<TConfig>(string sectionName)
        {
            try
            {
                return !string.IsNullOrEmpty(configFilePath)
                           ? GetConfiguration<TConfig>(configFilePath, sectionName)
                           : (TConfig)ConfigurationManager.GetSection(sectionName);
            }
            catch (Exception)
            {
                return default(TConfig);
            }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <typeparam name="TConfig">
        /// The type of the config.
        /// </typeparam>
        /// <param name="configPath">
        /// The exe path.
        /// </param>
        /// <param name="sectionName">
        /// Name of the section.
        /// </param>
        /// <returns>
        /// The config section
        /// </returns>
        public TConfig GetConfiguration<TConfig>(string configPath, string sectionName)
        {
            try
            {
                return (TConfig)new XmlSerializerSectionHandler().Create(configPath, sectionName);
            }
            catch (Exception)
            {
                return default(TConfig);
            }
        }

        /// <summary>
        /// The get connetion string.
        /// </summary>
        /// <param name="connectionName">
        /// The connection name.
        /// </param>
        /// <returns>The connection string setting for the supplied connection</returns>
        public ConnectionStringSettings GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName];
        }

        /// <summary>
        /// The set configuration file path.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void SetConfigurationFilePath(string filePath)
        {
            configFilePath = filePath;
        }

        #endregion
    }
}