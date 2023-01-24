using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] arr)
        {
            if (logger is null) { throw new ArgumentNullException(logger!.ToString()); }
            if (message == null) { throw new ArgumentNullException(message); }
            if (arr == null) { throw new ArgumentNullException("params is null in error"); }
            logger.Log(LogLevel.Error, string.Format(message, arr));
        }
        public static void Warning(this BaseLogger logger, string message, params object[] arr)
        {
            if (logger is null) { throw new ArgumentNullException(logger!.ToString()); }
            if (message == null) { throw new ArgumentNullException(message); }
            if (arr == null) { throw new ArgumentNullException("params is null in warning"); }
            logger.Log(LogLevel.Warning, string.Format(message, arr));
        }
        public static void Information(this BaseLogger logger, string message, params object[] arr)
        {
            if (logger is null) { throw new ArgumentNullException(logger!.ToString()); }
            if (message == null) { throw new ArgumentNullException(message); }
            if (arr == null) { throw new ArgumentNullException("params is null in info"); }
            logger.Log(LogLevel.Information, string.Format(message, arr));
        }
        public static void Debug(this BaseLogger logger, string message, params object[] arr)
        {
            if (logger is null) { throw new ArgumentNullException(logger!.ToString()); }
            if (message == null) { throw new ArgumentNullException(message); }
            if (arr == null) { throw new ArgumentNullException("params is null in debug"); }
            logger.Log(LogLevel.Debug, string.Format(message, arr));
        }
    }
}  
