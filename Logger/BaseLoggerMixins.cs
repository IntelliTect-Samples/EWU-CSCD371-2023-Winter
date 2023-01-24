﻿using System.Diagnostics;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);

        logger.Log(LogLevel.Error, string.Format(message, args));
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);

        logger.Log(LogLevel.Warning, string.Format(message, args));
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);

        logger.Log(LogLevel.Information, string.Format(message, args));
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        LoggerNullCheck(logger);

        logger.Log(LogLevel.Debug, string.Format(message, args));
    }

    public static void LoggerNullCheck(BaseLogger logger) 
    {
        if (logger is null) 
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
    }
}
