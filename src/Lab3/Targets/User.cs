using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Targets;

public class User : IRecieve
{
    private List<Message> _unreadMessages = new();
    private List<Message> _readMessages = new();

    public void RecieveMessage(Message message)
    {
        _unreadMessages.Add(message);
    }

    public void ReadMessage(int numberOfMessage)
    {
        _readMessages.Add(_unreadMessages[numberOfMessage]);
        _unreadMessages.RemoveAt(numberOfMessage); // Add catch
    }
}