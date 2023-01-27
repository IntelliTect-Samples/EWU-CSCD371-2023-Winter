using System;
using System.IO;

namespace Logger;
internal class FileLogger : BaseLogger
{
    private readonly StreamWriter LogFile;
    public FileLogger(string logPath) {
        LogFile = new StreamWriter(logPath, true);
    }
    public override void Log(LogLevel logLevel, string message)
    {
        LogFile.WriteLine($"[{DateTime.Now} {CallingClass} {logLevel}] {message}");
        LogFile.Flush();
        LogFile.Dispose();
    }
}
