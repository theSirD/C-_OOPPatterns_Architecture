using System;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Targets.Display;

public class DisplayDriver
{
    private readonly ILogger _logger = new Logger();

    public void ClearConsole()
    {
        Console.Clear();
        _logger.LogOneMessage("DisplayDriver: Console was cleared");
    }

    public void SetConsoleColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        _logger.LogOneMessage($"DisplayDriver: Color was set to {color}");
    }

    public void PrintOnConsole(string text)
    {
        _logger.LogOneMessage($"DisplayDriver: {text}");
    }
}