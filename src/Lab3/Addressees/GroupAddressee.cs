using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : BaseAddressee
{
    private List<BaseAddressee> _addresseesList;

    public GroupAddressee(ConfidentialityLevels confLevelAccess, ILogger logger)
        : base(confLevelAccess, logger)
    {
        _addresseesList = new();
    }

    public void AddNewAddressee(BaseAddressee addressee) => _addresseesList.Add(addressee);

    public override void Send()
    {
        if (CurrentMessage is null)
            throw new MessageIsNotSpecifiedException("Addressee does not contain a message");

        bool anyAddresseeHasNoRightToReadMessage = _addresseesList.Any(
            addressee => CurrentMessage.ConfidentialityLevel > addressee.ConfidentialityLevelAccess);

        if (!anyAddresseeHasNoRightToReadMessage)
        {
            foreach (BaseAddressee addressee in _addresseesList)
            {
                addressee.Send();
            }
        }
        else
        {
            throw new TargetIsProhibitedToReadException("One of given addresses does not have a right to read this message");
        }
    }
}