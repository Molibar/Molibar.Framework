namespace Molibar.Infrastructure.Configuration
{
    public abstract class ConfigurationPropertyHolder
    {
        private readonly IConfigurationSettingsProvider _configurationSettingsProvider;
        public string Context { get; private set; }

        protected ConfigurationPropertyHolder(string context, IConfigurationSettingsProvider configurationSettingsProvider)
        {
            _configurationSettingsProvider = configurationSettingsProvider;
            Context = context;
            Init();
        }

        internal void Init()
        {
            _configurationSettingsProvider.PopulateSettings(this);
        }
    }
}