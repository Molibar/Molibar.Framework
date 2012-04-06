using System;
using System.Collections.Generic;
using Molibar.Infrastructure.Configuration;
using Molibar.Infrastructure.Configuration.Model;
using Molibar.Infrastructure.Logging;
using NUnit.Framework;
using Rhino.Mocks;

namespace Molibar.Framework.UnitTest.Infrastructure.Configuration
{
    [TestFixture]
    class ConfigurationSettingsProviderTest
    {
        protected MockRepository _mock;
        protected ConfigurationSettingsProvider _configurationSettingsProvider;
        protected IConfigurationSettingsRepository _configurationSettingsRepository;
        protected ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _mock = new MockRepository();
            _configurationSettingsRepository = _mock.StrictMock<IConfigurationSettingsRepository>();
            _logger = _mock.StrictMock<ILogger>();
            _configurationSettingsProvider = new ConfigurationSettingsProvider(_configurationSettingsRepository, _logger);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentExceptionIfConfigurationSettingsProviderIsCreatedWith_Null_As_RepositoryInstance()
        {
            // Arrange

            // Act
            new ConfigurationSettingsProvider(null, _logger);

            // Assert
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentExceptionIfConfigurationSettingsProviderIsCreatedWith_Null_As_LoggerInstance()
        {
            // Arrange

            // Act
            new ConfigurationSettingsProvider(_configurationSettingsRepository, null);

            // Assert
        }

        [Test]
        public void ShouldCall_ConfigurationSettingsRepository_GetConfigurationSettingsDictionary_With_Context()
        {
            // Arrange
            const string context = "Ninja";
            var configurationDictionary = new Dictionary<string, ConfigurationSetting>();
            _configurationSettingsRepository.Expect(x => x.GetConfigurationSettingsDictionary(context)).Return(configurationDictionary).Repeat.Once();
            _mock.ReplayAll();

            // Act
            new DummyConfigurationPropertyHolder(context, _configurationSettingsProvider);

            // Assert
            _configurationSettingsRepository.VerifyAllExpectations();
        }


        [Test]
        public void ShouldPopulate_Properties_With_SameNameAs_ConfigurationSettingKey()
        {
            // Arrange
            const string context = "Ninja";
            const int idOne = 1;
            const string keyOne = "Kusarigama";
            const string valueOne = "You could poke someones eye out with that..";
            const int idTwo = 2;
            const string keyTwo = "Shuriken";
            const string valueTwo = "Watch out!";
            const int idThree = 3;
            const string keyThree = "NotThisNinjas";
            const string valueThree = "Someone elses SmokeBombs";
            var configurationDictionary =
                new Dictionary<string, ConfigurationSetting>
                    {
                        {keyOne, new ConfigurationSetting(idOne, context, keyOne, valueOne)},
                        {keyTwo, new ConfigurationSetting(idTwo, context, keyTwo, valueTwo)},
                        {keyThree, new ConfigurationSetting(idThree, context, keyThree, valueThree)}
                    };

            _configurationSettingsRepository.Expect(x => x.GetConfigurationSettingsDictionary(context)).Return(
                configurationDictionary).Repeat.Once();
            _mock.ReplayAll();

            // Act
            var dummyConfigurationSettings = new DummyConfigurationPropertyHolder(context, _configurationSettingsProvider);

            // Assert
            _configurationSettingsRepository.VerifyAllExpectations();
            Assert.That(dummyConfigurationSettings.Kusarigama, Is.EqualTo(valueOne));
            Assert.That(dummyConfigurationSettings.Shuriken, Is.EqualTo(valueTwo));
            Assert.That(dummyConfigurationSettings.MissingConfigurationSettings, Is.Null);
        }

        internal class DummyConfigurationPropertyHolder : ConfigurationPropertyHolder
        {
            public string Kusarigama { get; set; }
            public string Shuriken { get; set; }
            public string MissingConfigurationSettings { get; set; }

            public DummyConfigurationPropertyHolder(string context, IConfigurationSettingsProvider configurationSettingsProvider)
                : base(context, configurationSettingsProvider)
            {

            }
        }
    }
}
