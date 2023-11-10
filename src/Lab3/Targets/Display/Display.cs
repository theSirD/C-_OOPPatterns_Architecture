using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Targets.Display;

public class Display : IRecieve
{
    private readonly DisplayDriver _driver = new DisplayDriver();

    private Message? _currentMessage;
    public void RecieveMessage(Message message)
    {
        if (message is null)
            throw new ArgumentException("Given message is null");
        _currentMessage = message;
    }

    public void ClearConsole()
    {
        _driver.ClearConsole();
    }

    public void LogCurrentMessage(ConsoleColor colorOfText)
    {
        _driver.SetConsoleColor(colorOfText);

        if (_currentMessage is null)
            throw new ArgumentException("Display does not have a message now");
        _driver.PrintOnConsole(_currentMessage.Header);
        _driver.PrintOnConsole(_currentMessage.Body);
        _driver.PrintOnConsole(_currentMessage.ConfidentialityLevel.ToString());
        _currentMessage = null;
    }
}