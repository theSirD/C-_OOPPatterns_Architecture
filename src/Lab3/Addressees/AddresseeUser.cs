using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeUser : BaseAddressee
{
    public AddresseeUser(ConfidentialityLevels confLevelAccess)
        : base(confLevelAccess) { }
    public override void Send(IRecieve target)
    {
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");
        target?.RecieveMessage(CurrentMessage);
    }
}