using System;
using System.Diagnostics;

namespace Logger;

public class LogFactory
{
    private string LogFilePath = "";
    public void ConfigureLogger(string filePath)
    {
        LogFilePath = filePath;
    }
    public BaseLogger? CreateLogger(string className)
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
        log.CallingClass = new StackFrame(1).GetMethod().DeclaringType.Name;
        return log;
    }
}
