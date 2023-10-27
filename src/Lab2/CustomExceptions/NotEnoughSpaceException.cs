using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

public class NotEnoughSpaceException : Exception
{
    public NotEnoughSpaceException(string message)
        : base(message)
    {
    }

    public NotEnoughSpaceException()
    {
    }

    public NotEnoughSpaceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}