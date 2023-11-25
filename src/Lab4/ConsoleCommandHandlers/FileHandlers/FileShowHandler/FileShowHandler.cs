using System;

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
        string address = Context.Parser.Current;
        address = address.Substring(1, address.Length - 2);
        Context.Info.Path1 = address;
        Context.Parser.MoveForward();
        string flag = Context.Parser.Current;
        Context.Info.Flag = flag;
        if (address.Length == 0)
            throw new ArgumentException("Address for 'file show' is required");
        _chainOfFlagHandlers.Handle(flag, address);
    }

    public override bool CanHandle(string request)
    {
        return request == "show";
    }
}