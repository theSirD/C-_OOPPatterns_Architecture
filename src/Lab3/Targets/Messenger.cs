using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Targets;

public class Messenger : IRecieve
{
    private readonly ILogger _logger = new Logger();
    private List<Message> _messages = new();

    public void RecieveMessage(Message message)
    {
        if (message is null)
            throw new ArgumentException("Given message is null");

        _messages.Add(message);
    }

    public void LogAllMessages()
    {
        for (int i = 0; i < _messages.Count; i++)
        {
            _logger.LogOneMessage($"Messenger. Message {i + 1}:");
            _logger.LogOneMessage(_messages[i].Header);
            _logger.LogOneMessage(_messages[i].Body);
            _logger.LogOneMessage(_messages[i].ConfidentialityLevel.ToString());
        }
    }
}