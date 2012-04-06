using System;
using log4net.Core;

namespace Molibar.Infrastructure.Logging.ForTesting
{
    public class LogEntry
    {
        public Level Level { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public LogEntry(Level level, string message, Exception exception = null)
        {
            Level = level;
            Message = message;
            Exception = exception;
        }
    }
}