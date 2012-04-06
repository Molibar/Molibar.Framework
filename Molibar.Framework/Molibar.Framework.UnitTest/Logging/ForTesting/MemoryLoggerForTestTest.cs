using System;
using Molibar.Infrastructure.Logging.ForTesting;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.Logging.ForTesting
{
    [TestFixture]
    class MemoryLoggerForTestTest
    {
        [Test]
        public void ShouldAddOneMessageOfEachTypeToTheLogger()
        {
            // Arrange
            var expectedCount = 5;
            var memoryLoggerForTest = new MemoryLoggerForTest();

            const string firstMessage = "I'm logging a debug message";
            const string secondMessage = "I'm logging an info message";
            const string thirdMessage = "I'm logging an warn message";
            const string fourthMessage = "I'm logging an error message";
            const string fifthMessage = "I'm logging an fatal message";

            var secondException = new Exception("Info");
            var fourthException = new Exception("Error");

            // Act
            memoryLoggerForTest.Debug(firstMessage);
            memoryLoggerForTest.Info(secondMessage, secondException);
            memoryLoggerForTest.Warn(thirdMessage);
            memoryLoggerForTest.Error(fourthMessage, fourthException);
            memoryLoggerForTest.Fatal(fifthMessage);

            var first = memoryLoggerForTest.LogEntries[0];
            var second = memoryLoggerForTest.LogEntries[1];
            var third = memoryLoggerForTest.LogEntries[2];
            var fourth = memoryLoggerForTest.LogEntries[3];
            var fifth = memoryLoggerForTest.LogEntries[4];

            // Assert
            Assert.That(memoryLoggerForTest.LogEntries.Count, Is.EqualTo(expectedCount));

            Assert.That(first.Message, Is.EqualTo(firstMessage));
            Assert.That(first.Exception, Is.Null);

            Assert.That(second.Message, Is.EqualTo(secondMessage));
            Assert.That(second.Exception, Is.SameAs(secondException));

            Assert.That(third.Message, Is.EqualTo(thirdMessage));
            Assert.That(third.Exception, Is.Null);

            Assert.That(fourth.Message, Is.EqualTo(fourthMessage));
            Assert.That(fourth.Exception, Is.SameAs(fourthException));

            Assert.That(fifth.Message, Is.EqualTo(fifthMessage));
            Assert.That(fifth.Exception, Is.Null);
        }
    }
}
