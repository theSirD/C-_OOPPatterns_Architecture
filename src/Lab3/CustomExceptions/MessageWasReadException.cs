using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;

public class MessageWasReadException : Exception
{
    public MessageWasReadException(string message)
        : base(message)
    {
    }

    public MessageWasReadException()
    {
    }

    public MessageWasReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}