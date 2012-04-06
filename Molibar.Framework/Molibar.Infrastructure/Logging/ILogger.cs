using System;

namespace Molibar.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogDebugMessage(Type source, string message, Exception exception = null);
        void LogInfoMessage(Type source, string message, Exception exception = null);
        void LogWarnMessage(Type source, string message, Exception exception = null);
        void LogErrorMessage(Type source, string message, Exception exception = null);
        void LogFatalMessage(Type source, string message, Exception exception = null);
    }
}