namespace Logger
{
    public abstract class BaseLogger
    {
        private string? _Name;
        public string Name
        {
            get
            {
                return _Name!;
            }
            set
            {
                _Name = value;
            }
        }
        public abstract void Log(LogLevel logLevel, string message);
    }
}
