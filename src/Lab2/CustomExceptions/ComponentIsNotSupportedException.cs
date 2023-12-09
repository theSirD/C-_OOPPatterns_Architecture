using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

public class ComponentIsNotSupportedException : Exception
{
    public ComponentIsNotSupportedException(string message)
        : base(message)
    {
    }

    public ComponentIsNotSupportedException()
    {
    }

    public ComponentIsNotSupportedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}