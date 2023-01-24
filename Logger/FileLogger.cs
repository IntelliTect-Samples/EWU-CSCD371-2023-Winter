using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter stream = File.AppendText(FilePath);
            stream.Write(string.Format($"{DateTime.Now} {ClassName} {logLevel}: {message}\n"));
            //stream.Write(DateTime.Now.ToString());
            //stream.Write(" " + ClassName);
            //stream.Write(" " + logLevel + ":");
            //stream.Write(" " + message);
            //stream.WriteLine();
            stream.Close();
        }
    }
}