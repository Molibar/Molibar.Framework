using System;
using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    public class StringTools_StripNonNumeric_Test
    {
        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Input cannot be null",
            MatchType = MessageMatch.Exact)]
        public void StripNonNumericNullParameter()
        {
            StringTools.StripNonNumeric(null);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Input cannot be null",
            MatchType = MessageMatch.Exact)]
        public void StripNonNumericEmptyString()
        {
            StringTools.StripNonNumeric(String.Empty);
        }

        [Test]
        public void StripNonNumericAllNumbers()
        {
            String input = "123";
            var result = StringTools.StripNonNumeric(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result);
        }

        [Test]
        public void StripNonNumericAllText()
        {
            String input = "ABC";
            var result = StringTools.StripNonNumeric(input);

            Assert.IsNull(result);
        }

        [Test]
        public void StripNonNumericCombination()
        {
            String input = "ABC123";
            var result = StringTools.StripNonNumeric(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result);
        }

        [Test]
        public void StripNonNumericSpecialCharacters()
        {
            String input = "123!£$%&@?";
            var result = StringTools.StripNonNumeric(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("123", result);
        }

        [Test]
        public void StripNonNumericDecimal()
        {
            String input = "12.3";
            var result = StringTools.StripNonNumeric(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("12.3", result);
        }
    }
}
