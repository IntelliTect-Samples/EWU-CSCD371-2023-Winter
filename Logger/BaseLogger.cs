namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract void Log(LogLevel logLevel, string message);
    }
    class FileLogger : BaseLogger
    {
        public override void Log(LogLevel logLevel, string message)
        {

        }
    }
}
