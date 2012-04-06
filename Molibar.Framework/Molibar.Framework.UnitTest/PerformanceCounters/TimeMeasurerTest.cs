using Molibar.Infrastructure.PerformanceCounters;
using NUnit.Framework;

namespace Molibar.Framework.UnitTest.PerformanceCounters
{
    [TestFixture]
    public class TimeMeasurerTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ShouldReturnNanosecondsForExactlyOneSecond()
        {
            // Arrange
            var nanosecondsPerSecond = 1000000000;
            var start = 1234567890L;
            var stop = start + nanosecondsPerSecond;
            var timeMeasurer = new TimeMeasurer(start, stop, nanosecondsPerSecond);

            // Act
            var result = timeMeasurer.Nanoseconds;

            // Assert
            Assert.That(result, Is.EqualTo(nanosecondsPerSecond));
        }

        [Test]
        public void ShouldReturnTimeSpanForExactlyOneSecond()
        {
            // Arrange
            var millisecondsPerSecond = 1000;
            var nanosecondsPerSecond = 1000000000;
            var start = 1234567890L;
            var stop = start + nanosecondsPerSecond;
            var timeMeasurer = new TimeMeasurer(start, stop, nanosecondsPerSecond);

            // Act
            var result = timeMeasurer.TimeSpan;

            // Assert
            Assert.That(result.TotalMilliseconds, Is.EqualTo(millisecondsPerSecond));
        }
    }
}