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
        if (Parser is null)
            throw new ArgumentException("You need to pass a parser first");

        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        Parser.MoveForward();
        string address = Parser.Current;
        address = address.Substring(1, address.Length - 2);
        Info.Path1 = address;
        if (address.Length == 0)
            throw new ArgumentException("For 'tree goto' command address is required");
        if (FileSystem is null)
            throw new ArgumentException("You are not connected to FS yet");
        FileSystem.TreeGoTo(address);
    }

    public override bool CanHandle(string request)
    {
        return request == "goto";
    }
}