using Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;
using Itmo.ObjectOrientedProgramming.Lab3.Targets.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : BaseAddressee
{
    public DisplayAddressee(ConfidentialityLevels confLevelAccess, ILogger logger)
        : base(confLevelAccess, logger) { }

    public void SetTarget(IRecieve target)
    {
        if (target is not Display)
            throw new WrongTargetSpecifiedException("Only target for this addressee is Display");
        Target = target;
    }

    public override void Send()
    {
        if (Target is null)
            throw new TargetIsNotSpecifiedException("Specified user is null");
        if (CurrentMessage is null)
            throw new MessageIsNotSpecifiedException("Addressee does not contain a message");
        Target.RecieveMessage(CurrentMessage);
    }
}