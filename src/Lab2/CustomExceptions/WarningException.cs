using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

public class WarningException : Exception
{
    public WarningException(string message)
        : base(message)
    {
    }

    public WarningException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WarningException()
    {
    }
}