using System.IO;
using System;

namespace Logger
{
    public abstract class BaseLogger
    {
        public string? ClassName { get; set; }

        public abstract void Log(LogLevel logLevel, string message);
    }
    class FileLogger : BaseLogger
    {
        private string _Path { get; }

        public FileLogger(string path)
        {
            _Path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter sw = File.AppendText(_Path))
            {
                sw.WriteLine($"{DateTime.Now} {ClassName} {logLevel}: {message}");
            }  
        }
    }
}
