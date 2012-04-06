using System.Configuration;

namespace Molibar.Infrastructure.Configuration.XMLConfigSection
{
    /// <summary>
    /// The IConfigurationProvider interface.
    /// </summary>
    public interface IConfigurationProvider
    {
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
        TConfig GetConfiguration<TConfig>();

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
        TConfig GetConfiguration<TConfig>(string sectionName);

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
        /// The configuration section
        /// </returns>
        TConfig GetConfiguration<TConfig>(string configPath, string sectionName);

        /// <summary>
        /// Sets the configuration file path.
        /// </summary>
        /// <param name="filePath">
        /// Sets the path to the configuration file for the application
        /// </param>
        void SetConfigurationFilePath(string filePath);

        /// <summary>
        /// Gets the connetion string.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>The connection string setting for the supplied connection</returns>
        ConnectionStringSettings GetConnectionString(string connectionName);

        #endregion
    }
}