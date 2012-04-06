namespace Molibar.Infrastructure.Configuration.Model
{
    public class ConfigurationSetting
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ConfigurationSetting()
        {
        }

        public ConfigurationSetting(int id = 0, string context = null, string key = null, string value = null)
        {
            Id = id;
            Context = context;
            Key = key;
            Value = value;
        }
    }
}
