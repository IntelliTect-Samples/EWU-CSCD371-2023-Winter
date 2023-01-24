# Assignment 2

## Overview

For this assignment we are going to build a simple logging system. It will append items to a file. Some code for this assignment is already provided. The purpose of the assignment is to explore topics like base classes, extension methods, object initialization, encapsulation, properties, and parameter arrays.

## Reading

Read **Chapters 4-6** with an **especially careful read of Chapter 6**. Pay special attention to areas unique to C# from other languages you know. 

## Assignment

- There is an existing `BaseLogger` class. It needs an **auto property** to hold a class name. This property should be set in the `LogFactory` using an **object initializer**. ❌✔
- Create a `FileLogger` that derives from `BaseLogger`. It should take in a path to a file to write the log message to. When its `Log` method is called, it should **append** messages on their own line in the file. The output should include all of the following:
  - The current date/time ❌✔
  - The name of the class that created the logger ❌✔
  - The log level ❌✔
  - The message ❌✔
  - The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
- The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a **private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. ❌✔
- If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`. ❌✔
- Inside of `BaseLoggerMixins` implement **extension methods** on `BaseLogger` for
  - `Error`, ❌✔
  - `Warning`, ❌✔
  - `Information`, and ❌✔
  - `Debug`. ❌✔
  Each of these methods should take in a `string` for the message, as well as a **parameter array** of arguments for the message. Each of these extension methods is expected to be a shortcut for calling the `BaseLogger.Log` method, by automatically supplying the appropriate `LogLevel`. These methods should throw an exception if the `BaseLogger` parameter is null. There are a couple example unit tests to get you started.
- Use the nameof() operator when identifying the class name to the logger ❌✔
- Ensure you turn on Warnings as Errors (TreatWarningsAsErrors) ❌✔
- Ensure that you turn on code analysis (EnableNETAnalyzers) ❌✔
- Ensure that you turn on CodeAnalysisTreatWarningsAsErrors ❌✔
- Set `LangVersion` and the `TargetFramework` to the latest released versions available (preview versions optional) ❌✔
- Turn on Nullability (`Nullable`) ❌✔
- **All of the above should be unit tested.**

## Extra Credit

- Implement an additional logger. This logger must be unit tested. Some options to consider could be one that uses `System.Console` or `System.Diagnostics.Trace` ❌✔
- Implement the factory pattern using static abstract methods on a Logger interface instead.

## Relevant APIs to know about

[System.IO.Path](https://docs.microsoft.com/en-us/dotnet/api/system.io.path) IF you find yourself using string operations to build up a file path, stop and look through the members of this static class.

[System.IO.File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file) A simple class that can handle simple file reads and writes.

## See [Docs](https://github.com/IntelliTect-Samples/EWU-CSCD371-2023-Winter/blob/main/Docs/README.md)
