using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers.TreeListHandler;

public class TreeListHandler : BaseHandler
{
    private IHandler _chainOfFlagHandlers;

    public TreeListHandler(Context context)
    : base(context)
    {
        _chainOfFlagHandlers = new SelectionDepthFlagHandler(context);
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
        Context.Parser.MoveForward();
        string flag = Context.Parser.Current;
        Context.Info.Flag = flag;
        if (flag.Length == 0)
            throw new ArgumentException("Flag is not specified");
        Context.Info.VisitedFlagHandlersList.Add("-d", false);
        while (Context.Parser.HasNextWord() && Context.Info.VisitedFlagHandlersList.Any((s) => s.Value == false))
            _chainOfFlagHandlers.Handle();
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.TreeList(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "list";
    }
}