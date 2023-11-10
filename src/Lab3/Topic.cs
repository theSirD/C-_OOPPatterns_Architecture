using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private BaseAddressee _addressee;

    public Topic(string title, BaseAddressee addressee)
    {
        Title = title;
        _addressee = addressee;
    }

    public string Title { get; private set; }

    public void PassMessageToAddressee(Message message)
    {
        _addressee.CurrentMessage = message;
    }
}