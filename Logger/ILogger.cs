namespace Logger;

public interface ILogger
{
    string LogSource { get; } // Many of you refer to this as the ClassName.
    void Log(LogLevel logLevel, string message);

    // While interesting, this is probably better implemented using a factory class.
    // because you can't have static abstract members on classes
    // and you can't have covariant return types on interface members. :(
    static abstract ILogger CreateLogger(in ILoggerConfiguration configuration);
}
