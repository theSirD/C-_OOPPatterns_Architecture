using System;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

public class TreeHandler : BaseHandler
{
    private readonly BaseHandler _chainOfSubcommandHandlers = new TreeGoToHandler();

    public TreeHandler()
    {
        NextHandler = new FileHandler();
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
        }

        Parser.MoveForward();
        string subcommand = Parser.Current;
        if (subcommand.Length == 0)
            throw new ArgumentException("For 'tree' command subcommand is required");
        _chainOfSubcommandHandlers.Handle(subcommand, string.Empty);
    }

    public override bool CanHandle(string request)
    {
        return request == "tree";
    }
}