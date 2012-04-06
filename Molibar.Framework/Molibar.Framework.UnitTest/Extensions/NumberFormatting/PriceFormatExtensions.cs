using Molibar.Infrastructure.Extensions.NumberFormatting;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Extensions.NumberFormatting
{
    [TestFixture]
    public class PriceFormatExtensionsTests
    {

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeZeroPointFiveAsDecimalValue()
        {
            // Arrange
            var price = -0.5d;
            var expected = "-£0.50";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForZeroPointFiveAsDecimalValue()
        {
            // Arrange
            var price = 0.5d;
            var expected = "£0.50";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeZeroAsDecimalValue()
        {
            // Arrange
            var price = -0d;
            var expected = "£0.00";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForZeroAsDecimalValue()
        {
            // Arrange
            var price = 0d;
            var expected = "£0.00";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForSingleDigitWithZeroAsDecimalValue()
        {
            // Arrange
            var price = 1.00d;
            var expected = "£1.00";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForSingleDigit()
        {
            // Arrange
            var price = 1.23d;
            var expected = "£1.23";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForTwoDigit()
        {
            // Arrange
            var price = 12.34d;
            var expected = "£12.34";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForThreeDigit()
        {
            // Arrange
            var price = 123.45d;
            var expected = "£123.45";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForFourDigit()
        {
            // Arrange
            var price = 1234.56d;
            var expected = "£1,234.56";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForFiveDigit()
        {
            // Arrange
            var price = 12345.67d;
            var expected = "£12,345.67";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForSixDigit()
        {
            // Arrange
            var price = 123456.78d;
            var expected = "£123,456.78";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForSevenDigit()
        {
            // Arrange
            var price = 1234567.89d;
            var expected = "£1,234,567.89";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }






        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeSingleDigitWithZeroAsDecimalValue()
        {
            // Arrange
            var price = -1.00d;
            var expected = "-£1.00";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeSingleDigit()
        {
            // Arrange
            var price = -1.23d;
            var expected = "-£1.23";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeTwoDigit()
        {
            // Arrange
            var price = -12.34d;
            var expected = "-£12.34";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeThreeDigit()
        {
            // Arrange
            var price = -123.45d;
            var expected = "-£123.45";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeFourDigit()
        {
            // Arrange
            var price = -1234.56d;
            var expected = "-£1,234.56";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeFiveDigit()
        {
            // Arrange
            var price = -12345.67d;
            var expected = "-£12,345.67";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeSixDigit()
        {
            // Arrange
            var price = -123456.78d;
            var expected = "-£123,456.78";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturnWellFormattedPriceStringWhen_ToFormattedPrice_IsCalledForNegativeSevenDigit()
        {
            // Arrange
            var price = -1234567.89d;
            var expected = "-£1,234,567.89";

            // Act
            var result = price.ToFormattedPrice();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}