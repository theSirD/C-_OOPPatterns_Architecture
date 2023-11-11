using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomExceptions;

public class MessageIsNotSpecifiedException : Exception
{
    public MessageIsNotSpecifiedException(string message)
        : base(message)
    {
    }

    public MessageIsNotSpecifiedException()
    {
    }

    public MessageIsNotSpecifiedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}