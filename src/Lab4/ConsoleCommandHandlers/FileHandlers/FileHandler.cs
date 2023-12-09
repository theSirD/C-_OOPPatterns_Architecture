using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers;

public class FileHandler : BaseHandler
{
    private BaseHandler _chainOfSubcommandHandlers;

    public FileHandler(Context context)
    : base(context)
    {
        _chainOfSubcommandHandlers = new FileShowHandler.FileShowHandler(context);
    }

    public override void Handle()
    {
        if (Context is null || Context.Info is null || Context.Parser is null)
        {
            throw new ArgumentException("Context object is not initialized properly");
        }

        if (!CanHandle())
        {
            if (NextHandler is null)
                throw new ArgumentException("Can not do the command");
            NextHandler.Handle();
            return;
        }

        Context.Parser.MoveForward();
        string subcommand = Context.Parser.Current;
        Context.Info.Subcommand = subcommand;
        if (subcommand.Length == 0)
            throw new ArgumentException("For 'file' command subcommand is required");
        _chainOfSubcommandHandlers.Handle();
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Command == "file";
    }
}