using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Targets;

public class User : IRecieve
{
    private List<Message> _unreadMessages = new();
    private List<Message> _readMessages = new();

    public User(string name)
    {
        Name = name;
    }

    public string? Name { get; private set; }

    public void RecieveMessage(Message message)
    {
        _unreadMessages.Add(message);
    }

    public void ReadMessage(Message message)
    {
        if (message is null)
            throw new ArgumentException("Given message is null");
        for (int i = 0; i < _unreadMessages.Count; i++)
        {
            if (_unreadMessages[i].Header == message.Header &&
                _unreadMessages[i].Body == message.Body &&
                _unreadMessages[i].ConfidentialityLevel == message.ConfidentialityLevel)
            {
                _unreadMessages.RemoveAt(i);
                _readMessages.Add(message);
                return;
            }
        }

        throw new ArgumentException("Given message is either already read or user never recieved it");
    }

    public bool CheckIfMessageIsUnread(string header)
    {
        foreach (Message message in _unreadMessages)
        {
            if (message.Header == header) return true;
        }

        return false;
    }

    public bool CheckIfMessageIsRead(string header)
    {
        foreach (Message message in _readMessages)
        {
            if (message.Header == header) return true;
        }

        return false;
    }
}