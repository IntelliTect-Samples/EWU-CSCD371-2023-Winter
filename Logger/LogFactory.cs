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
        if (LogFilePath == null)
        {
            return null;
        }
        BaseLogger? log;
        switch (className)
        {
            case "FileLogger":
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
