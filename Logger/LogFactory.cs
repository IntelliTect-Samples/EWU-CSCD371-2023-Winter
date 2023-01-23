namespace Logger
{
    public class LogFactory
    {
        private string? _pathName;

        public BaseLogger? CreateLogger(string className)
        {
            if (_pathName == null)
            {
                return null;
            }
            else
            {
                ConfigureFileLogger(_pathName);
                BaseLogger baseLogger = new FileLogger(_pathName) { ClassName = className };
                return baseLogger;
            }
        }
       
        public void ConfigureFileLogger(string filePath)
        {
            _pathName = filePath;
        }
    }
}
