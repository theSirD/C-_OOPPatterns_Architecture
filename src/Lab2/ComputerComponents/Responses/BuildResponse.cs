namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Responses;

public class BuildResponse
{
    public BuildResponse(ComputerConfiguration computer, string message)
    {
        Computer = computer;
        Message = message;
    }

    public ComputerConfiguration Computer { get; private init; }
    public string Message { get; private init; }
}