using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

public class NotEnoughPortsException : Exception
{
    public NotEnoughPortsException(string message)
        : base(message)
    {
    }

    public NotEnoughPortsException()
    {
    }

    public NotEnoughPortsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}