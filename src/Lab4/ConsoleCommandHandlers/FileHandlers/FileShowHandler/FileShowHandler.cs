using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.FileHandlers.FileShowHandler;

public class FileShowHandler : BaseHandler
{
    private readonly IHandler _chainOfFlagHandlers;

    public FileShowHandler(Context context)
    : base(context)
    {
        _chainOfFlagHandlers = new FileOutputModeFlagHandler(context);
        NextHandler = new FileMoveHandler(context);
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
        if (address.Length == 0)
            throw new ArgumentException("Address for 'file show' is required");
        Context.Info.VisitedFlagHandlersList.Add("-m", false);
        while (Context.Parser.HasNextWord() && Context.Info.VisitedFlagHandlersList.Any((s) => s.Value == false))
            _chainOfFlagHandlers.Handle();
        if (Context.FileSystem is null)
            throw new ArgumentException("You need to connect to FS first");
        Context.FileSystem.FileShow(Context);
    }

    public override bool CanHandle()
    {
        if (Context is null || Context.Info is null)
            throw new ArgumentException("Context object is not initialized properly");
        return Context.Info.Subcommand == "show";
    }
}