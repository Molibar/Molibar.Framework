using System;

namespace Molibar.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        public void LogDebugMessage(Type source, string message, Exception exception = null)
        {
            Log.DebugMessage(source, message, exception);
        }

        public void LogInfoMessage(Type source, string message, Exception exception = null)
        {
            Log.InfoMessage(source, message, exception);
        }

        public void LogWarnMessage(Type source, string message, Exception exception = null)
        {
            Log.WarnMessage(source, message, exception);
        }

        public void LogErrorMessage(Type source, string message, Exception exception = null)
        {
            Log.ErrorMessage(source, message, exception);
        }

        public void LogFatalMessage(Type source, string message, Exception exception = null)
        {
            Log.FatalMessage(source, message, exception);
        }
    }
}