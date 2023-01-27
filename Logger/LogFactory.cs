using System;
using System.Diagnostics;

namespace Logger;

public class LogFactory
{
    public string? LogFilePath { get; set; }
    public void ConfigureLogger(string filePath)
    {
        LogFilePath = filePath;
    }
    public BaseLogger? CreateLogger(string className, string callingClass)
    {
        BaseLogger? log;
        switch (className)
        {
            case "ConsoleLogger":
                log = new ConsoleLogger();
                log.ClassName = className;
                break;
            case "FileLogger":
                if (LogFilePath is null)
                    return null;
                log = new FileLogger(LogFilePath);
                log.ClassName = className;
                break;
            default:
                throw new ArgumentException($"Unrecognized className argument '{className}");
        }
        log.CallingClass = callingClass;
        return log;
    }
}
