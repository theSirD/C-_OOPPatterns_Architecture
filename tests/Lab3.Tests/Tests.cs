using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
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
        var userAddressee = new UserAddressee(ConfidentialityLevels.High);
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
        var userAddressee = new UserAddressee(ConfidentialityLevels.High);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.Medium);
        topic1.PassMessageToAddressee(msg1);
        var user1 = new User("User1");
        userAddressee.SetTarget(user1);
        userAddressee.Send();
        user1.ReadMessage(0);
        Assert.True(!user1.CheckIfMessageIsUnread("H1") && user1.CheckIfMessageIsRead("H1"));
    }

    [Fact]
    public void TooHighPriority()
    {
        ILogger logger = Substitute.For<ILogger>();
        var userAddressee = new UserAddressee(ConfidentialityLevels.Medium);
        var topic1 = new Topic("topic1", userAddressee);
        var msg1 = new Message("H1", "B1", ConfidentialityLevels.High);
        topic1.PassMessageToAddressee(msg1);

        logger.Received(1).LogOneMessage("This addressee does not have right to read this message");
    }
}