using System;

namespace Logger;
internal class ConsoleLogger : BaseLogger
{
    public override void Log(LogLevel logLevel, string message)
    {
        string msgOut = $"[{DateTime.Now} {CallingClass}";
        switch (logLevel)
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

        Console.WriteLine(msgOut + "] " + message);
    }
}
