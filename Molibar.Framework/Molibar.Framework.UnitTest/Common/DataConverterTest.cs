using System;
using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    public class DataConverterTest
    {

        [Test]
        public void ShouldReturn_Default_Guid_ForString_null_ToGuid()
        {
            // Arrange
            Guid expected = new Guid();
            string input = null;

            // Act
            var result = DataConverter.ToGuid(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void ShouldReturn_null_ForString_null_ToInt32()
        {
            // Arrange
            int? expected = null;
            string input = null;

            // Act
            var result = DataConverter.ToNullableInt32(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturn_3_ForString_3_ToInt32()
        {
            // Arrange
            var expected = 3;
            var input = "3";

            // Act
            var result = DataConverter.ToNullableInt32(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrow_FormatException_ForString_keff_ToInt32()
        {
            // Arrange
            var input = "keff";

            // Act
            var result = DataConverter.ToNullableInt32(input);

            // Assert
        }

        [Test]
        public void ShouldReturn_null_ForString_null_ToInt16()
        {
            // Arrange
            int? expected = null;
            string input = null;

            // Act
            var result = DataConverter.ToNullableInt16(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturn_3_ForString_3_ToInt16()
        {
            // Arrange
            var expected = 3;
            var input = "3";

            // Act
            var result = DataConverter.ToNullableInt16(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrow_FormatException_ForString_keff_ToInt16()
        {
            // Arrange
            var input = "keff";

            // Act
            var result = DataConverter.ToNullableInt16(input);

            // Assert
        }

        [Test]
        public void ShouldReturn_null_ForString_null_ToInt64()
        {
            // Arrange
            int? expected = null;
            string input = null;

            // Act
            var result = DataConverter.ToNullableInt64(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturn_3_ForString_3_ToInt64()
        {
            // Arrange
            var expected = 3;
            var input = "3";

            // Act
            var result = DataConverter.ToNullableInt64(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrow_FormatException_ForString_keff_ToInt64()
        {
            // Arrange
            var input = "keff";

            // Act
            var result = DataConverter.ToNullableInt64(input);

            // Assert
        }


        [Test]
        public void ShouldReturn_null_ForString_null_ToGuid()
        {
            // Arrange
            Guid? expected = null;
            string input = null;

            // Act
            var result = DataConverter.ToNullableGuid(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void ShouldReturn_SameGuid_ForString_Guid_ToGuid()
        {
            // Arrange
            Guid? expected = new Guid("017d090d-55d7-4261-aebe-eb8a926381c3");
            var input = "017d090d-55d7-4261-aebe-eb8a926381c3";

            // Act
            var result = DataConverter.ToNullableGuid(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrow_FormatException_ForString_keff_ToGuid()
        {
            // Arrange
            var input = "keff";

            // Act
            var result = DataConverter.ToNullableGuid(input);

            // Assert
        }


        [Test]
        public void ShouldReturn_Default_IfInput_Null()
        {
            // Arrange
            TestEnum expected = 0;
            string input = null;

            // Act
            var result = DataConverter.ToEnum<TestEnum>(typeof(TestEnum), input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturn_Zero_IfInput_Zero()
        {
            // Arrange
            TestEnum expected = TestEnum.Zero;
            string input = "Zero";

            // Act
            var result = DataConverter.ToEnum<TestEnum>(typeof(TestEnum), input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldReturn_Two_IfInput_Two()
        {
            // Arrange
            TestEnum expected = TestEnum.Two;
            string input = "Two";

            // Act
            var result = DataConverter.ToEnum<TestEnum>(typeof(TestEnum), input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        public enum TestEnum
        {
            Zero = 0,
            One = 1,
            Two = 2
        }
    }
}
