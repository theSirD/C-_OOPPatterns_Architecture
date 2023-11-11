using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : BaseAddressee
{
    public MessengerAddressee(ConfidentialityLevels confLevelAccess, ILogger logger)
        : base(confLevelAccess, logger) { }

    public void SetTarget(IRecieve target)
    {
        if (target is not Messenger)
            throw new ArgumentException("Only target for this addressee is Messenger");
        Target = target;
    }

    public override void Send()
    {
        if (Target is null)
            throw new ArgumentException("Specified messenger is null");
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");
        Target.RecieveMessage(CurrentMessage);
    }
}