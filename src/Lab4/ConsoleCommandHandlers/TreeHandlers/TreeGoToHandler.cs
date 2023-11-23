using System;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

public class TreeGoToHandler : BaseHandler
{
    public TreeGoToHandler()
    {
        NextHandler = new TreeListHandler.TreeListHandler();
    }

    public override void Handle(string request, string path)
    {
        if (!CanHandle(request))
        {
            if (NextHandler is null)
                Console.WriteLine("Can not do the command");
            else
                NextHandler.Handle(request, string.Empty);
        }

        string? address = Parser?.SearchForPath();
        if (address is not null)
        {
            if (address.Length == 0)
                throw new ArgumentException("For 'tree goto' command address is required");
            if (FileSystem is null)
                throw new ArgumentException("You are not connected to FS yet");
            FileSystem.TreeGoTo(address);
        }
    }

    public override bool CanHandle(string request)
    {
        return request == "goto";
    }
}