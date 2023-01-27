using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string _filePath;
        public FileLogger(string filePath)
        {
            if(filePath is null)
            {
                throw new System.ArgumentNullException(nameof(filePath));
            }
            _filePath = filePath;    
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter sw = File.AppendText(message);
            sw.WriteLine($"{DateTime.Now} {ClassName} {logLevel} {message}");           
            sw.Flush();         
            sw.Close();
        }
    }
}
