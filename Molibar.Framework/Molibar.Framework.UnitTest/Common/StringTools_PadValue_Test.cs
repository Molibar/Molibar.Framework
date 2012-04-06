using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    public class StringTools_PadValue_Test
    {
        [Test]
        public void Should_Return_0000_For_PadValue_if_Value0_and_requiredLength4()
        {
            // Arrange
            var expected = "0000";
            var value = 0;

            // Act
            var result = StringTools.PadValue(value, 4);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void Should_Return_0001_For_PadValue_if_Value1_and_requiredLength4()
        {
            // Arrange
            var expected = "0001";
            var value = 1;

            // Act
            var result = StringTools.PadValue(value, 4);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void Should_Return_1200_For_PadValue_if_Value0_requiredLength4_and_LocationAppend()
        {
            // Arrange
            var expected = "1200";
            var value = 12;

            // Act
            var result = StringTools.PadValue(value, 4, location: Location.Append);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void Should_Return_xxx0_For_PadValue_if_Value0_and_requiredLength4()
        {
            // Arrange
            var expected = "xxx0";
            var value = 0;

            // Act
            var result = StringTools.PadValue(value, 4, 'x');

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}