using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    public class StringToolsTest
    {
        [Test]
        public void Should_return_application_page_aspx_for_application_page_aspx_user_bill_when_char_is_questionmark()
        {
            // Arrange
            var expected = "application/page.aspx";
            var character = '?';
            var filename = "application/page.aspx?user=bill";

            // Act
            var result = StringTools.StripFromChar(character, filename);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_original_string_if_encoded_and_then_decoded()
        {
            // Arrange
            var complexString = "åäö!#¤%&/(=?воздается國";
            var expected = complexString;

            // Act
            var encoded = StringTools.EncodeBase64(complexString);
            var result = StringTools.DecodeBase64(encoded);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
