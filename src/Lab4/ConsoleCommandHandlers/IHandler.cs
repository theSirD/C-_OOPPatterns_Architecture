namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers;

public interface IHandler
{
    public static InfoAboutExecutedCommand Info { get; set; } = new InfoAboutExecutedCommand();
    public void Handle(string request, string path);

    public bool CanHandle(string request);
}