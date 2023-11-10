using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : BaseAddressee
{
    public MessengerAddressee(ConfidentialityLevels confLevelAccess)
        : base(confLevelAccess) { }
    public override void Send(IRecieve target)
    {
        if (target is null)
            throw new ArgumentException("Specified messenger is null");
        if (target is not Messenger)
            throw new ArgumentException("Only target for this addressee is Messenger");
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");
        target.RecieveMessage(CurrentMessage);
    }
}