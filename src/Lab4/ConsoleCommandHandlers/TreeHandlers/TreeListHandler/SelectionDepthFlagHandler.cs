using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers.TreeListHandler;

public class SelectionDepthFlagHandler : BaseHandler
{
    public SelectionDepthFlagHandler(Context context)
    : base(context)
    {
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
                throw new ArgumentException("Unknown flag");
            NextHandler.Handle();
            return;
        }

        Context.Info.VisitedFlagHandlersList["-d"] = true;
        Context.Parser.MoveForward();
        string flagArgument = Context.Parser.Current;
        Context.Info.FlagArguments[Context.Info.Flag] = flagArgument;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Flag argument is not specified after flag");
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Flag == "-d";
    }
}