using System;
using System.IO;
using System.Text;
using Logger;


namespace Logger 
{
	public class FileLogger : BaseLogger
	{
		public string _path { get; }
		public FileLogger(string path)
        {
            _path = path;
            ClassName = nameof(FileLogger);
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if(!File.Exists(_path)) { throw new SystemException("Path to file does not exist."); }
            DateTime date = DateTime.Now;
            string log = $"{date} {ClassName} {Enum.GetName(typeof(LogLevel), logLevel)}: {message}";
            StreamWriter streamWriter = File.AppendText(_path);
            streamWriter.WriteLine(log);
            streamWriter.Close();
        }
    }
}
