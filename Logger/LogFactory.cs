namespace Logger
{
    public class LogFactory
    {
        private string? FilePath { get; set; }
        public BaseLogger? CreateLogger(string className)
        {
            if (FilePath is not null)
            {
                FileLogger fileLogger = new FileLogger(FilePath) {ClassName = className};
                return fileLogger;
            }
            return null;
        }
        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
