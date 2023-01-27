
using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Debug(BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Debug, string.Format(message, args));
        }

        public static void Error(BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, string.Format(message, args));
        }

        public static void Info(BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Information, string.Format(message, args));
        }

        public static void Warning(BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Warning, string.Format(message, args));
        }
    }
    }
