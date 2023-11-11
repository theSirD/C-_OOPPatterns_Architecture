using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : BaseAddressee
{
    public UserAddressee(ConfidentialityLevels confLevelAccess, ILogger logger)
        : base(confLevelAccess, logger) { }

    public void SetTarget(IRecieve target)
    {
        if (target is not User)
            throw new ArgumentException("Only target for this addressee is User");
        Target = target;
    }

    public override void Send()
    {
        if (Target is null)
            throw new ArgumentException("Specified user is null");
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");
        Target.RecieveMessage(CurrentMessage);
    }
}