namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public interface IHandler
{
    public void Handle();

    public bool CanHandle();
}