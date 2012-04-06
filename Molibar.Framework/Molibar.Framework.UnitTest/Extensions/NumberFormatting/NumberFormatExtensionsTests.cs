using Molibar.Infrastructure.Extensions.NumberFormatting;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Extensions.NumberFormatting
{
    public class NumberFormatExtensionsTests
    {

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeZeroPointFiveAsDecimalValue()
        {
            // Arrange
            var value = -0.5d;
            var expected = "-0.50";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForZeroPointFiveAsDecimalValue()
        {
            // Arrange
            var value = 0.5d;
            var expected = "0.50";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeZeroAsDecimalValue()
        {
            // Arrange
            var value = -0d;
            var expected = "0.00";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForZeroAsDecimalValue()
        {
            // Arrange
            var value = 0d;
            var expected = "0.00";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForSingleDigitWithZeroAsDecimalValue()
        {
            // Arrange
            var value = 1.00d;
            var expected = "1.00";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForSingleDigit()
        {
            // Arrange
            var value = 1.23d;
            var expected = "1.23";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForTwoDigit()
        {
            // Arrange
            var value = 12.34d;
            var expected = "12.34";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForThreeDigit()
        {
            // Arrange
            var value = 123.45d;
            var expected = "123.45";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForFourDigit()
        {
            // Arrange
            var value = 1234.56d;
            var expected = "1,234.56";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForFiveDigit()
        {
            // Arrange
            var value = 12345.67d;
            var expected = "12,345.67";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForSixDigit()
        {
            // Arrange
            var value = 123456.78d;
            var expected = "123,456.78";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForSevenDigit()
        {
            // Arrange
            var value = 1234567.89d;
            var expected = "1,234,567.89";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }






        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeSingleDigitWithZeroAsDecimalValue()
        {
            // Arrange
            var value = -1.00d;
            var expected = "-1.00";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeSingleDigit()
        {
            // Arrange
            var value = -1.23d;
            var expected = "-1.23";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeTwoDigit()
        {
            // Arrange
            var value = -12.34d;
            var expected = "-12.34";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeThreeDigit()
        {
            // Arrange
            var value = -123.45d;
            var expected = "-123.45";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeFourDigit()
        {
            // Arrange
            var value = -1234.56d;
            var expected = "-1,234.56";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeFiveDigit()
        {
            // Arrange
            var value = -12345.67d;
            var expected = "-12,345.67";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeSixDigit()
        {
            // Arrange
            var value = -123456.78d;
            var expected = "-123,456.78";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedString_IsCalledForNegativeSevenDigit()
        {
            // Arrange
            var value = -1234567.89d;
            var expected = "-1,234,567.89";

            // Act
            var result = value.ToFormattedString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
