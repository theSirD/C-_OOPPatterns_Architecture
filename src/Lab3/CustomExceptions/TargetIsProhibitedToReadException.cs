using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;

public class TargetIsProhibitedToReadException : Exception
{
    public TargetIsProhibitedToReadException(string message)
        : base(message)
    {
    }

    public TargetIsProhibitedToReadException()
    {
    }

    public TargetIsProhibitedToReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}