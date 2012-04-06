using System;
using System.Collections.Generic;
using log4net;
using log4net.Core;

namespace Molibar.Infrastructure.Logging.ForTesting
{
    public class MemoryLoggerForTest : ILog
    {
        public IList<LogEntry> LogEntries { get; internal set; }

        public MemoryLoggerForTest()
        {
            LogEntries = new List<LogEntry>();
        }

        public void Debug(object message, Exception exception)
        {
            LogEntries.Add(new LogEntry(Level.Debug, (string)message, exception));
        }
        public void Info(object message, Exception exception)
        {
            LogEntries.Add(new LogEntry(Level.Info, (string)message, exception));
        }
        public void Warn(object message, Exception exception)
        {
            LogEntries.Add(new LogEntry(Level.Warn, (string)message, exception));
        }
        public void Error(object message, Exception exception)
        {
            LogEntries.Add(new LogEntry(Level.Error, (string)message, exception));
        }

        public void Fatal(object message, Exception exception)
        {
            LogEntries.Add(new LogEntry(Level.Fatal, (string)message, exception));
        }


        private bool _isDebugEnabled = true;
        private bool _isInfoEnabled = true;
        private bool _isWarnEnabled = true;
        private bool _isErrorEnabled = true;
        private bool _isFatalEnabled = true;

        public bool IsDebugEnabled { get { return _isDebugEnabled; } set { _isDebugEnabled = value; } }
        public bool IsInfoEnabled { get { return _isInfoEnabled; } set { _isInfoEnabled = value; } }
        public bool IsWarnEnabled { get { return _isWarnEnabled; } set { _isWarnEnabled = value; } }
        public bool IsErrorEnabled { get { return _isErrorEnabled; } set { _isErrorEnabled = value; } }
        public bool IsFatalEnabled { get { return _isFatalEnabled; } set { _isFatalEnabled = value; } }


        public log4net.Core.ILogger Logger
        {
            get { throw new NotImplementedException(); }
        }

        public void Debug(object message)
        {
            LogEntries.Add(new LogEntry(Level.Debug, (string)message));
        }

        public void DebugFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(object message)
        {
            LogEntries.Add(new LogEntry(Level.Info, (string)message));
        }

        public void InfoFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(object message)
        {
            LogEntries.Add(new LogEntry(Level.Warn, (string)message));
        }

        public void WarnFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(object message)
        {
            LogEntries.Add(new LogEntry(Level.Error, (string)message));
        }

        public void ErrorFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object message)
        {
            LogEntries.Add(new LogEntry(Level.Fatal, (string)message));
        }

        public void FatalFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}