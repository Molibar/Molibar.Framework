using System;
using Molibar.Infrastructure.Logging;
using NUnit.Framework;
using Rhino.Mocks;
using log4net;

namespace Molibar.Framework.UnitTest.Infrastructure.Logging
{
    [TestFixture]
    class LogTest
    {
        private MockRepository _mock;
        private ILog _log;

        [SetUp]
        public void SetUp()
        {
            _mock = new MockRepository();
            _log = _mock.StrictMock<ILog>();
        }

        [Test]
        public void ShouldAssertThatOneCanOverrideThe_ILog_OfThe_Log_Class()
        {
            // Arrange
            var type = typeof(LogTest);
            new Log(_log);

            const bool enabled = true;

            const string firstMessage = "I'm logging a debug message";
            const string secondMessage = "I'm logging an info message";
            const string thirdMessage = "I'm logging an warn message";
            const string fourthMessage = "I'm logging an error message";
            const string fifthMessage = "I'm logging an fatal message";

            var secondException = new Exception("Info");
            var fourthException = new Exception("Error");

            _log.Expect(x => x.IsDebugEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsInfoEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsWarnEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsErrorEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsFatalEnabled).Return(enabled).Repeat.Once();

            _log.Expect(x => x.Info(secondMessage, secondException)).Repeat.Once();
            _log.Expect(x => x.Debug(firstMessage, null)).Repeat.Once();
            _log.Expect(x => x.Warn(thirdMessage, null)).Repeat.Once();
            _log.Expect(x => x.Error(fourthMessage, fourthException)).Repeat.Once();
            _log.Expect(x => x.Fatal(fifthMessage, null)).Repeat.Once();
            _mock.ReplayAll();

            // Act
            Log.DebugMessage(type, firstMessage);
            Log.InfoMessage(type, secondMessage, secondException);
            Log.WarnMessage(type, thirdMessage);
            Log.ErrorMessage(type, fourthMessage, fourthException);
            Log.FatalMessage(type, fifthMessage);

            // Assert
            _log.VerifyAllExpectations();
        }

        [Test]
        public void ShouldAssertThatNoLoggingWillBeDoneIf_LoggingIsDisabled()
        {
            // Arrange
            const bool enabled = false;
            var type = typeof(LogTest);
            new Log(_log);


            const string firstMessage = "I'm logging a debug message";
            const string secondMessage = "I'm logging an info message";
            const string thirdMessage = "I'm logging an warn message";
            const string fourthMessage = "I'm logging an error message";
            const string fifthMessage = "I'm logging an fatal message";

            var secondException = new Exception("Info");
            var fourthException = new Exception("Error");

            _log.Expect(x => x.IsDebugEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsInfoEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsWarnEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsErrorEnabled).Return(enabled).Repeat.Once();
            _log.Expect(x => x.IsFatalEnabled).Return(enabled).Repeat.Once();

            _log.Expect(x => x.Info(null, null)).IgnoreArguments().Repeat.Never();
            _log.Expect(x => x.Debug(null, null)).IgnoreArguments().Repeat.Never();
            _log.Expect(x => x.Warn(null, null)).IgnoreArguments().Repeat.Never();
            _log.Expect(x => x.Error(null, null)).IgnoreArguments().Repeat.Never();
            _log.Expect(x => x.Fatal(null, null)).IgnoreArguments().Repeat.Never();
            _mock.ReplayAll();

            // Act
            Log.DebugMessage(type, firstMessage);
            Log.InfoMessage(type, secondMessage, secondException);
            Log.WarnMessage(type, thirdMessage);
            Log.ErrorMessage(type, fourthMessage, fourthException);
            Log.FatalMessage(type, fifthMessage);

            // Assert
            _log.VerifyAllExpectations();
        }

        [Test]
        public void Fluff()
        {
            //PerformanceCounterCategory.Delete("Molibar.Framework");
        }
    }
}
