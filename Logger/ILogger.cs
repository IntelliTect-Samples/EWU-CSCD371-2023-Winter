namespace Logger;

public interface ILogger<TLogger, TLoggerConfiguration>
{
    string LogSource { get; } // Many of you refer to this as the ClassName.
    void Log(LogLevel logLevel, string message);

    static abstract TLogger CreateLogger(TLoggerConfiguration configuration);
}
