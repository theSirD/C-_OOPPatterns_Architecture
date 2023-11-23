namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public interface IHandler
{
    public void Handle(string request, string path);

    public bool CanHandle(string request);
}