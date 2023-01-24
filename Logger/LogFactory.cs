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

    public string ConfigureFileLogger
    {
        get 
        {
            return _Path!;
        }
        set 
        { 
            _Path = value;
        }  
    }
}
