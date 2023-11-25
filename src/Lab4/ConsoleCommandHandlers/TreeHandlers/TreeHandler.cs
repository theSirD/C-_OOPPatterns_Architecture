using System;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

public class TreeHandler : BaseHandler
{
    private BaseHandler _chainOfSubcommandHandlers;

    public TreeHandler(Context context)
    : base(context)
    {
        NextHandler = new FileHandler(context);
        _chainOfSubcommandHandlers = new TreeGoToHandler(context);
    }

    public override void Handle(string request, string path)
    {
        if (Context is null || Context.Info is null || Context.Parser is null)
        {
            throw new ArgumentException("Context object is not initialized properly");
        }

        if (!CanHandle(request))
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle(request, string.Empty);
            return;
        }

        Context.Parser.MoveForward();
        string subcommand = Context.Parser.Current;
        Context.Info.Subcommand = subcommand;
        if (subcommand.Length == 0)
            throw new ArgumentException("For 'tree' command subcommand is required");
        _chainOfSubcommandHandlers.Handle(subcommand, string.Empty);
    }

    public override bool CanHandle(string request)
    {
        return request == "tree";
    }
}