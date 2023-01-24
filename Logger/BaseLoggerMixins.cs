namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] list)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException("null BaseLogger in Error");
            }

            baseLogger.Log(LogLevel.Error, string.Format(message, list));
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] list) 
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException("null BaseLogger in Warning");
            }

            baseLogger.Log(LogLevel.Warning, string.Format(message, list));
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] list)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException("null BaseLogger in Information");
            }

            baseLogger.Log(LogLevel.Information, string.Format(message, list));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] list)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException("null BaseLogger in Debug");
            }

            baseLogger.Log(LogLevel.Debug, string.Format(message, list));
        }
    }
}
