using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger b, string message, params object[] arguments)
    {
        if (b is null)
        {
            throw new ArgumentNullException();
        } else
        {
            LogLevel logLvl = LogLevel.Error;
            b.Log(logLvl, string.Format(message, arguments));
        }
    }
    public static void Warning(this BaseLogger b, string message, params object[] arguments)
    {
        if (b is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            LogLevel logLvl = LogLevel.Warning;
            b.Log(logLvl, string.Format(message, arguments));
        }
    }
    public static void Information(this BaseLogger b, string message, params object[] arguments)
    {
        if (b is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            LogLevel logLvl = LogLevel.Information;
            b.Log(logLvl, string.Format(message, arguments));
        }
    }
    public static void Debug(this BaseLogger b, string message, params object[] arguments)
    {
        if (b is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            LogLevel logLvl = LogLevel.Debug;
            b.Log(logLvl, string.Format(message, arguments));
        }
    }
}
