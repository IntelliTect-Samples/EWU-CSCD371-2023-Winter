﻿using System;
namespace Logger;

public class LogFactory
{
    private string _FilePath;
    public BaseLogger CreateLogger(string className)
    {
        
        return null;
        if (_FilePath == null) {
            return null;
        }
        return new FileLogger(_FilePath) { ClassName = className };
    }
    public void ConfigureFileLogger(string filePath) { _FilePath = filePath; }
}
