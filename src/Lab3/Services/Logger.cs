using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Logger : ILogger
{
    public void LogOneMessage(string text)
    {
        Console.WriteLine(text);
    }
}