using System;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.ConnectHandler;

public class ConnectionModeFlagHandler : BaseHandler
{
    public ConnectionModeFlagHandler(Context context)
        : base(context)
    {
    }

    public override void Handle()
    {
        if (Context is null || Context.Info is null || Context.Parser is null || Context.FileSystem is null)
        {
            throw new ArgumentException("Context object is not properly initialized");
        }

        if (Context.Info.Path1 is null)
            throw new ArgumentException("You need to specify path first");

        if (!CanHandle())
        {
            if (NextHandler is not null)
            {
                NextHandler.Handle();
                return;
            }
            else
            {
                throw new ArgumentException("Unknown connection mode flag");
            }
        }

        Context.Info.VisitedFlagHandlersList["-m"] = true;
        Context.Parser.MoveForward();
        string flagArgument = Context.Parser.Current;
        Context.Info.FlagArguments[Context.Info.Flag] = flagArgument;
        if (flagArgument.Length == 0)
            throw new ArgumentException("Connection mode after flag is not specified");
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Flag == "-m";
    }
}