using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath;
        public FileLogger(string filePath, string name)
        {
            if(filePath is null)
            {
                throw new System.ArgumentNullException("Null file path in FileLogger");
            }
            FilePath = filePath;
            Name = nameof(FileLogger);    
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter sw = File.AppendText(message);
            sw.Write(DateTime.Now + " ");
            sw.Write(nameof(FileLogger) + " "); 
            sw.Write(logLevel + " ");
            sw.WriteLine(message);
            sw.Flush();         
            sw.Close();
        }
    }
}
