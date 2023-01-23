using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] paths)
        {
            if (logger == null)
            {
                throw new System.ArgumentNullException(nameof(logger));
            }
            else
            {
                logger.Log(LogLevel.Error, string.Format(message, paths));
            }
        }
        public static void Warning(this BaseLogger logger, string message, params object[] paths)
        {
            if (logger == null)
            {
                throw new System.ArgumentNullException(nameof(logger));
            }
            else
            {
                logger.Log(LogLevel.Warning, string.Format(message, paths));
            }
        }
        public static void Information(this BaseLogger logger, string message, params object[] paths)
        {
            if (logger == null)
            {
                throw new System.ArgumentNullException(nameof(logger));
            }
            else
            {
                logger.Log(LogLevel.Information, string.Format(message, paths));
            }
        }
        public static void Debug(this BaseLogger logger, string message, params object[] paths)
        {
            if (logger == null)
            {
                throw new System.ArgumentNullException(nameof(logger));
            }
            else
            {
                logger.Log(LogLevel.Debug, string.Format(message, paths));
            }
        }
    }
}