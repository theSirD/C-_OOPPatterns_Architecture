using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;

public class WrongTargetSpecifiedException : Exception
{
    public WrongTargetSpecifiedException(string message)
        : base(message)
    {
    }

    public WrongTargetSpecifiedException()
    {
    }

    public WrongTargetSpecifiedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}