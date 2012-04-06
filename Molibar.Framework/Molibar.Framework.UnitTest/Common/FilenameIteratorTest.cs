using Molibar.Common;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Common
{
    [TestFixture]
    class FilenameIteratorTest
    {
        [Test]
        public void Should_return_file_1_for_file_when_iterateAfterExtension()
        {
            // Arrange
            var expected = "file.1";
            var filename = "file";

            // Act
            var result = FilenameIterator.Iterate(filename, true);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_3_for_file_2_when_iterateAfterExtension()
        {
            // Arrange
            var expected = "file.3";
            var filename = "file.2";

            // Act
            var result = FilenameIterator.Iterate(filename, true);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_txt_1_for_file_txt_when_iterateAfterExtension()
        {
            // Arrange
            var expected = "file.txt.1";
            var filename = "file.txt";

            // Act
            var result = FilenameIterator.Iterate(filename, true);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_txt_2_for_file_txt_1_when_iterateAfterExtension()
        {
            // Arrange
            var expected = "file.txt.2";
            var filename = "file.txt.1";

            // Act
            var result = FilenameIterator.Iterate(filename, true);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        
        [Test]
        public void Should_return_file_1_for_file_when_iterateAfterExtension_false()
        {
            // Arrange
            var expected = "file.1";
            var filename = "file";

            // Act
            var result = FilenameIterator.Iterate(filename, false);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_1_2_for_file_2_when_iterateAfterExtension_false()
        {
            // Arrange
            var expected = "file.1.2";
            var filename = "file.2";

            // Act
            var result = FilenameIterator.Iterate(filename, false);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_2_2_for_file_1_2_when_iterateAfterExtension_false()
        {
            // Arrange
            var expected = "file.2.2";
            var filename = "file.1.2";

            // Act
            var result = FilenameIterator.Iterate(filename, false);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_1_txt_for_file_txt_when_iterateAfterExtension_false()
        {
            // Arrange
            var expected = "file.1.txt";
            var filename = "file.txt";

            // Act
            var result = FilenameIterator.Iterate(filename, false);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_file_2_txt_for_file_1_txt_when_iterateAfterExtension_false()
        {
            // Arrange
            var expected = "file.2.txt";
            var filename = "file.1.txt";

            // Act
            var result = FilenameIterator.Iterate(filename, false);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
