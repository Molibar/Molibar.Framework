using System;
using System.Collections.Generic;
using log4net;
using log4net.Core;

namespace Molibar.Infrastructure.Logging
{
    public class Log
    {
        internal static string ApplicationName { get; set; }

        private static LogPerformanceCounterIterator
            _logPerformanceCounterIterator = new LogPerformanceCounterIterator();

        private static ILog _overridingLogger;
        private static Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();
        private static readonly object _lock = new object();


        /// <summary>
        /// This constructor should ONLY be called if you want to override the
        /// standard behaviour of this logging class. For instance if you want
        /// to override the config file in case of testing or such.
        /// </summary>
        /// <param name="overridingLogger">
        /// A implementation or the ILog interface. MemoryLoggerForTest could
        /// be sent in here. That way you can verify everything that is logged.
        /// </param>
        public Log(ILog overridingLogger)
        {
            _overridingLogger = overridingLogger;
        }

        private static ILog GetLogger(Type source)
        {
            lock (_lock)
            {
                if (_loggers.ContainsKey(source))
                {
                    return _loggers[source];
                }
                // If there is an overriding logger set by the constructor that
                // will be returned regardless off the 
                if (_overridingLogger != null)
                {
                    return _overridingLogger;
                }
                var logger = LogManager.GetLogger(source);
                _loggers.Add(source, logger);
                return logger;
            }
        }

        public static void DebugMessage(Type source, string message, Exception exception = null)
        {
            var log = GetLogger(source);
            if (log.IsDebugEnabled)
            {
                ProcessLogEntry(log, Level.Debug, message, exception);
            }
        }

        public static void InfoMessage(Type source, string message, Exception exception = null)
        {
            var log = GetLogger(source);
            if (log.IsInfoEnabled)
            {
                ProcessLogEntry(log, Level.Info, message, exception);
            }
        }

        public static void WarnMessage(Type source, string message, Exception exception = null)
        {
            var log = GetLogger(source);
            if (log.IsWarnEnabled)
            {
                ProcessLogEntry(log, Level.Warn, message, exception);
            }
        }

        public static void ErrorMessage(Type source, string message, Exception exception = null)
        {
            var log = GetLogger(source);
            if (log.IsErrorEnabled)
            {
                ProcessLogEntry(log, Level.Error, message, exception);
            }
        }

        public static void FatalMessage(Type source, string message, Exception exception = null)
        {
            var log = GetLogger(source);
            if (log.IsFatalEnabled)
            {
                ProcessLogEntry(log, Level.Fatal, message, exception);
            }
        }

        public delegate void LoggerCall(object message, Exception exception);

        private static void ProcessLogEntry(ILog log, Level level, string message, Exception exception)
        {
            _logPerformanceCounterIterator.OnEntry(level, exception);
            PreProcessLogEntry(level, exception);
            if (level.Value == Level.Debug.Value)
            {
                log.Debug(message, exception);
            }
            else if (level.Value == Level.Info.Value)
            {
                log.Info(message, exception);
            }
            else if (level.Value == Level.Warn.Value)
            {
                log.Warn(message, exception);
            }
            else if (level.Value == Level.Error.Value)
            {
                log.Error(message, exception);
            }
            else if (level.Value == Level.Fatal.Value)
            {
                log.Fatal(message, exception);
            }
            PostProcessLogEntry();
        }

        private static void PreProcessLogEntry(Level level, Exception exception)
        {
            NDC.Push(ApplicationName);
        }

        private static void PostProcessLogEntry()
        {
            NDC.Pop();
        }
    }
}