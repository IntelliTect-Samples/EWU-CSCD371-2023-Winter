namespace Logger
{
    public class LogFactory
    {
        private string filePath { get; set; }
        public BaseLogger CreateLogger(string className)
        {
            if (filePath is not null)
            {

            }
            return null;
        }
        public void configureFileLogger(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
