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

    public void ReadMessage(int numberOfMessage)
    {
        _readMessages.Add(_unreadMessages[numberOfMessage]);
        _unreadMessages.RemoveAt(numberOfMessage); // Add catch
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