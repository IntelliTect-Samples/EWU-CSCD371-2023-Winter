using System;
using System.Linq;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger log, string message, params object[] args)
    {
        if (log is null)
        {
            throw new ArgumentNullException("log must not be null");
        }
        log.Log(LogLevel.Error, String.Format(message, args));
    }

    public static void Warning(this BaseLogger log, string message, params object[] args)
    {
        if (log is null) 
        {
            throw new ArgumentNullException("log must not be null");
        }
        log.Log(LogLevel.Warning, $"{message} {args}");
    }

    public static void Information(this BaseLogger log, string message, params object[] args)
    {
        if(log is null)
        {
            throw new ArgumentNullException("log must not be null");
        }
        log.Log(LogLevel.Information, $"{message} {args}");
    }

    public static void Debug(this BaseLogger log, string message, params object[] args) 
    {
        if(log is null)
        {
            throw new ArgumentNullException("log must not be null");
        }
        log.Log(LogLevel.Debug, $"{message} {args}");
    }
}

