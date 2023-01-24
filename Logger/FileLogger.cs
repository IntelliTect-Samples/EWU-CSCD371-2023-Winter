using System;
using System.IO;

namespace Logger;
internal class FileLogger : BaseLogger
{
    private StreamWriter LogFile;
    public FileLogger(string logPath) {
        LogFile = new StreamWriter(logPath, true);
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string msgOut = $"[{DateTime.Now} {CallingClass} ";
        switch(logLevel)
        {
            case LogLevel.Error:
                msgOut += "Error";
                break;
            case LogLevel.Warning:
                msgOut += "Warning";
                break;
            case LogLevel.Information:
                msgOut += "Information";
                break;
            case LogLevel.Debug:
                msgOut += "Debug";
                break;
        }

        LogFile.WriteLine(msgOut + "] " + message);
        LogFile.Flush();
    }
}
