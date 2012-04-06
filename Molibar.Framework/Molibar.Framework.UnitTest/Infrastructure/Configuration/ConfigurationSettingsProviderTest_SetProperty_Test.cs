using System;
using System.Reflection;
using Molibar.Infrastructure.Configuration;
using NUnit.Framework;
using Rhino.Mocks;

namespace Molibar.Framework.UnitTest.Infrastructure.Configuration
{
    [TestFixture]
    class ConfigurationSettingsProviderTest_SetProperty_Test : ConfigurationSettingsProviderTest
    {
        private PropertyInfo _propertyInfo;

        [SetUp]
        public void SetUp()
        {
            _propertyInfo = _mock.Stub<PropertyInfo>();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Int16()
        {
            // Arrange
            var type = typeof(Int16);
            var target = new object();
            var value = "16";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, (short)16, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Int32()
        {
            // Arrange
            var type = typeof(Int32);
            var target = new object();
            var value = "32";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, (int)32, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Int64()
        {
            // Arrange
            var type = typeof(Int64);
            var target = new object();
            var value = "64";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, (long)64, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_String()
        {
            // Arrange
            var type = typeof(string);
            var target = new object();
            var value = "string";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, value, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Decimal()
        {
            // Arrange
            var type = typeof(decimal);
            var target = new object();
            var value = "123";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, (decimal)123, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Double()
        {
            // Arrange
            var type = typeof(double);
            var target = new object();
            var value = "123";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, (double)123, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_SetValue_When_SetProperty_IsCalled_With_PropertyTypeName_Boolean()
        {
            // Arrange
            var type = typeof(bool);
            var target = new object();
            var value = "True";

            _propertyInfo.Expect(x => x.PropertyType).Return(type);
            _propertyInfo.Expect(x => x.SetValue(target, true, null));
            _propertyInfo.Replay();

            // Act
            _configurationSettingsProvider.SetProperty(_propertyInfo, target, value);

            // Assert
            _propertyInfo.VerifyAllExpectations();
        }

        [Test]
        public void Should_Log_PropertyConversionError_WhenUnknown_PropertyTypeName()
        {
            // Arrange
            const string value = "StrangeUnknownValue";
            const string message = "Can't convert StrangeUnknownValue to IntPtr for property System.Object.PropertyName";
            var obj = new object();
            var propertyInfo = _mock.Stub<PropertyInfo>();
            propertyInfo.Stub(x => x.Name).Return("PropertyName");
            propertyInfo.Stub(x => x.PropertyType).Return(typeof(IntPtr));
            _logger.Expect(
                x => x.LogErrorMessage(typeof(ConfigurationSettingsProvider), message)).Repeat.Once();
            _mock.ReplayAll();

            // Act
            _configurationSettingsProvider.SetProperty(propertyInfo, obj, value);

            // Assert
            _logger.VerifyAllExpectations();
        }
    }
}