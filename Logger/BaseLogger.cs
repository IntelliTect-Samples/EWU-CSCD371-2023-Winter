namespace Logger;

public abstract class BaseLogger
{
    public string? ClassName { get; set; }
    public string? CallingClass { get; set; }

    public abstract void Log(LogLevel logLevel, string message);
}

