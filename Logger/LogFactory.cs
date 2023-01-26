namespace Logger;

public class LogFactory
{
    private string? _Path;

    public BaseLogger CreateLogger(string className)
    {
        if(_Path == null)
        {
            return null!;
        }
        else
        {
            BaseLogger baseLogger = new FileLogger(_Path) { ClassName = className };
            return baseLogger;
        } 
    }

    public void ConfigureFileLogger(string path)
    {
       _Path = path;
    }
}
