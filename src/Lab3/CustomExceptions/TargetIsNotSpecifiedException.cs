using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;

public class TargetIsNotSpecifiedException : Exception
{
    public TargetIsNotSpecifiedException(string message)
        : base(message)
    {
    }

    public TargetIsNotSpecifiedException()
    {
    }

    public TargetIsNotSpecifiedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}