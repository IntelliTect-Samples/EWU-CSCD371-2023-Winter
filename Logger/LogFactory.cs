namespace Logger
{
    public class LogFactory
    {
        private string? _FileLoggerPath;
        public string? FileLoggerPath
        {
            get
            {
                return _FileLoggerPath;
            }
            private set
            {
                _FileLoggerPath = value;
            }
        }

        public void ConfigureFileLogger(string filePath)
        {
            FileLoggerPath = filePath;
        }

        public BaseLogger CreateLogger(string className)
        {
            if (FileLoggerPath is null) { return null!; }
            FileLogger fileLogger = new(filePath: FileLoggerPath)
            { ClassName = className };
            return fileLogger;
        }
    }
}