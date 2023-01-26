using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
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
