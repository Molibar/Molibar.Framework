using System.Collections.Generic;
using System.Linq;
using Molibar.Infrastructure.Configuration.Model;
using Molibar.Infrastructure.DataAccess;

namespace Molibar.Infrastructure.Configuration.Repositories
{
    public class MsSqlConfigurationSettingsRepository : IConfigurationSettingsRepository
    {
        private readonly IDbAccessor _dbAccessor;

        public MsSqlConfigurationSettingsRepository(IDatabaseConnectionStringProvider databaseConnectionStringProvider)
        {
            _dbAccessor = new DbAccessor(databaseConnectionStringProvider);
        }

        public IDictionary<string, ConfigurationSetting> GetConfigurationSettingsDictionary(string context)
        {
            var paramtersAndReader =
                new ParametersAndReader<ConfigurationSetting>
                {
                    Parameters = parameters => parameters.AddWithValue("Context", context),
                    RecordReader = reader => new ConfigurationSetting
                    {
                        Id = (int)reader["Id"],
                        Context = (string)reader["Context"],
                        Key = (string)reader["Key"],
                        Value = (string)reader["Value"]
                    }
                };

            var configurationSettings =
                _dbAccessor.PerformSpRead(paramtersAndReader, "[cfg_ConfigurationSettings_FindByContext]");

            // The Key should be the context combined with the key.
            return configurationSettings.ToDictionary(setting => setting.Key, setting => setting);
        }
    }
}
