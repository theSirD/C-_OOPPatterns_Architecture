using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]

    public void MsgGetsUnreadAfterBeingSentToUser()
    {
        var logger = new Logger();
        var userAddressee = new UserAddressee(ConfidentialityLevels.High, logger);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Medium);
        topic1.PassMessageToAddressee(msg1);
        var user1 = new User("User1");
        userAddressee.SetTarget(user1);
        userAddressee.Send();
        Assert.True(user1.CheckIfMessageIsUnread("H1"));
    }

    [Fact]

    public void MsgGetsRead()
    {
        var logger = new Logger();
        var userAddressee = new UserAddressee(ConfidentialityLevels.High, logger);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Medium);
        topic1.PassMessageToAddressee(msg1);
        var user1 = new User("User1");
        userAddressee.SetTarget(user1);
        userAddressee.Send();
        user1.ReadMessage(new Message("H1", "B1", ConfidentialityLevels.Medium));
        Assert.True(!user1.CheckIfMessageIsUnread("H1") && user1.CheckIfMessageIsRead("H1"));
    }

    [Fact]
    public void TryToReadReadMessage()
    {
        var logger = new Logger();
        var userAddressee = new UserAddressee(ConfidentialityLevels.High, logger);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Medium);
        topic1.PassMessageToAddressee(msg1);
        var user1 = new User("User1");
        userAddressee.SetTarget(user1);
        userAddressee.Send();
        user1.ReadMessage(msg1);

        string errorMessage = string.Empty;
        try
        {
            user1.ReadMessage(msg1);
        }
        catch (MessageWasReadException ex)
        {
            errorMessage = ex.Message;
        }

        Assert.True(errorMessage == "Given message is either already read or user never recieved it");
    }

    [Fact]
    public void TooHighPriority()
    {
        ILogger logger = Substitute.For<ILogger>();
        var userAddressee = new UserAddressee(ConfidentialityLevels.Medium, logger);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.High);
        topic1.PassMessageToAddressee(msg1);

        logger.Received(1).LogOneMessage("This addressee does not have right to read this message");
    }

    [Fact]
    public void AddresseeGotAMessage()
    {
        ILogger logger = Substitute.For<ILogger>();
        var userAddressee = new UserAddressee(ConfidentialityLevels.Medium, logger);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Low);

        topic1.PassMessageToAddressee(msg1);

        logger.Received(1).LogOneMessage("Addressee with got a message");
    }

    [Fact]
    public void MessengerGotAMessage()
    {
        ILogger logger = Substitute.For<ILogger>();
        var messengerAddressee = new MessengerAddressee(ConfidentialityLevels.Medium, logger);
        var topic1 = new Topic("topic1", messengerAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Low);
        topic1.PassMessageToAddressee(msg1);
        var messenger = new Messenger(logger);
        messengerAddressee.SetTarget(messenger);

        messengerAddressee.Send();

        logger.Received(1).LogOneMessage("Messenger recieved a message. Now it has 1 message(s)");
    }
}