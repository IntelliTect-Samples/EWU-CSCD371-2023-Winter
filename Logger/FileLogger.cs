using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string PathName { get; }

        public FileLogger(string pathName)
        {
            PathName = pathName;

            if (!File.Exists(pathName))
            {
                File.Create(pathName);
            }

        }
        public override void Log(LogLevel logLevel, string message)
        {
            if (!File.Exists(PathName))
            {
                throw new System.Exception("File Path does not exist");

            }
            using StreamWriter sw = File.CreateText(PathName);
            {
                sw.WriteLine($"{System.DateTime.Now} {ClassName} {logLevel + ":"} {message}");
            }
            
        }
    }
       
       
    
}