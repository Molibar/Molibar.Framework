using System;
using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    public class StringTools_Left_Test
    {

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Input parameter cannot be null", MatchType = MessageMatch.Exact)]
        public void LeftNullParameters()
        {
            StringTools.Left(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Length parameter must be greater than zero", MatchType = MessageMatch.Exact)]
        public void LeftBlankStringNegativeLength()
        {
            StringTools.Left(String.Empty, -5);
        }

        [Test]
        public void LeftBlankStringZeroLength()
        {
            var result = StringTools.Left(String.Empty, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void LeftBlankStringWithLength()
        {
            var result = StringTools.Left(String.Empty, 5);

            Assert.IsNotNull(result);
            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void LeftWithStringZeroLength()
        {
            var result = StringTools.Left("ABC", 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void LeftSameLengthAsString()
        {
            var result = StringTools.Left("ABC", 3);

            Assert.IsNotNull(result);
            Assert.AreEqual("ABC", result);
        }

        [Test]
        public void LeftLongStringWithLength()
        {
            var result = StringTools.Left("ABCDEF", 3);

            Assert.IsNotNull(result);
            Assert.AreEqual("ABC", result);
        }
    }
}