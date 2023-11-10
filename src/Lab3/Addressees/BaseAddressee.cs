using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class BaseAddressee
{
    private readonly ILogger _logger = new Logger();
    private Message? _currentMessage;
    protected BaseAddressee(ConfidentialityLevels confLevelAccess)
    {
        ConfidentialityLevelAccess = confLevelAccess;
    }

    public Message? CurrentMessage
    {
        get
        {
            return _currentMessage;
        }
        set
        {
            if (value is null)
                throw new ArgumentException("Message you've tried to pass to addressee is null");
            if (value.ConfidentialityLevel > ConfidentialityLevelAccess)
                throw new ArgumentException("This addressee does not have right to read this message");
            _currentMessage = value;
            _logger.LogOneMessage($"Addressee with a confidence level of {ConfidentialityLevelAccess} got a message");
        }
    }

    public ConfidentialityLevels ConfidentialityLevelAccess { get; private set; }

    protected IRecieve? Target { get; set; }

    public abstract void Send();
}