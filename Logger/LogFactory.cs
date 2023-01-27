namespace Logger
{
    public class LogFactory
    {
        private string? FilePath;

        public BaseLogger CreateLogger(string className)
        {
            if(FilePath is null)
            {
                return null!;
            }

            FileLogger output = new FileLogger(FilePath) {ClassName = className};
            return output;
        }

        public void ConfigureFileLogger(string pathname)
        {
            FilePath = pathname;
        }
    }
}
