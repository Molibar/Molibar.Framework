using Molibar.Infrastructure.Configuration;
using NUnit.Framework;
using Rhino.Mocks;

namespace Molibar.Framework.UnitTest.Configuration
{
    [TestFixture]
    class ConfigurationSettingsTest
    {
        private MockRepository _mock;
        private IConfigurationSettingsProvider _configurationSettingsProvider;

        [SetUp]
        public void SetUp()
        {
            _mock = new MockRepository();
            _configurationSettingsProvider = _mock.StrictMock<IConfigurationSettingsProvider>();
        }

        [Test]
        public void ShouldCall_ConfigurationSettingsProvider_PopulateSettings_FromConstructor()
        {
            // Arrange
            const string context = "Ninja";
            _configurationSettingsProvider.Expect(p => p.PopulateSettings(null)).IgnoreArguments().Repeat.Once();
            _mock.ReplayAll();

            // Act
            var configurationSettings = new DummyConfigurationPropertyHolder(context, _configurationSettingsProvider);

            // Assert
            _configurationSettingsProvider.VerifyAllExpectations();
        }

        [Test]
        public void ShouldSetContextTo_Ninja_Context()
        {
            // Arrange
            const string expected = "Ninja";
            const string context = "Ninja";
            var configurationSettings = new DummyConfigurationPropertyHolder(context, _configurationSettingsProvider);

            // Act
            configurationSettings.Init();

            // Assert
            Assert.That(configurationSettings.Context, Is.EqualTo(expected));
        }

        public class DummyConfigurationPropertyHolder : ConfigurationPropertyHolder
        {
            public DummyConfigurationPropertyHolder(string context, IConfigurationSettingsProvider configurationSettingsProvider)
                : base(context, configurationSettingsProvider)
            {
                
            }
        }
    }
}
