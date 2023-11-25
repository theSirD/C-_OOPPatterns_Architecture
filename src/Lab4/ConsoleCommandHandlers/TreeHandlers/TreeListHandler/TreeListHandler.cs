using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleCommandHandlers.TreeHandlers.TreeListHandler;

public class TreeListHandler : BaseHandler
{
    private readonly IHandler _chainOfFlagHandlers = new SelectionDepthFlagHandler();

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
        Parser.MoveForward();
        string flag = Parser.Current;
        if (flag.Length == 0)
            throw new ArgumentException("Flag is not specified");
        _chainOfFlagHandlers.Handle(flag, address);
    }

    public override bool CanHandle(string request)
    {
        return request == "list";
    }
}