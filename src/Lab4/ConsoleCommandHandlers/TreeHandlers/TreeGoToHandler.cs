using System;
namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers;

public class TreeGoToHandler : BaseHandler
{
    public TreeGoToHandler(Context context)
    : base(context)
    {
        NextHandler = new TreeListHandler.TreeListHandler(context);
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
        string address = Context.Parser.Current;
        address = address.Substring(1, address.Length - 2);
        Context.Info.Path1 = address;
        if (address.Length == 0)
            throw new ArgumentException("For 'tree goto' command address is required");
        if (Context.FileSystem is null)
            throw new ArgumentException("You are not connected to FS yet");
        Context.FileSystem.TreeGoTo(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "goto";
    }
}