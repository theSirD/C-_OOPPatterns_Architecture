using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

public class BuildLacksRequiredComponentsException : Exception
{
    public BuildLacksRequiredComponentsException(string message)
    : base(message)
    { }

    public BuildLacksRequiredComponentsException()
    {
    }

    public BuildLacksRequiredComponentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
