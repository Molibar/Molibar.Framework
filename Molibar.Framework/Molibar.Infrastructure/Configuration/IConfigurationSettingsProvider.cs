namespace Molibar.Infrastructure.Configuration
{
    public interface IConfigurationSettingsProvider
    {
        /// <summary>
        /// The class responsible for populating the properties of the
        /// ConfigurationPropertyHolder implementations.
        /// </summary>
        /// <param name="instance">The ConfigurationPropertyHolder implementation
        /// that will get it's properties set by the call to PopulateSettings</param>
        void PopulateSettings(ConfigurationPropertyHolder instance);
    }
}
